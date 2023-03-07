using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace PartyPlayer;

public class ConsoleManager
{
    public static ConsoleManager Manager;
    public static bool End = false;
    private static readonly object _messageLock = new();

    private static readonly Regex FullPattern =
        new("^([a-zA-Z0-9]+)(([ ]?[/-]([a-zA-Z0-9]+)(([ ]([a-zA-Z0-9_\\.]+))|([ ]?[\'][^']+[\']))?)+)?$");

    private static readonly Regex ArgumentPattern =
        new("[ ]?[/-]([a-zA-Z0-9]+)(?:(?:(?:[ ])([a-zA-Z0-9_\\.]+))|(?:(?:[ ]?)(?:[\'])([^']+)(?:[\'])))?");

    private readonly Dictionary<string, Command> _commands = new();

    private ConsoleManager()
    {
        Write("PartyPlayer", ConsoleColor.Magenta)
            .Space()
            .Write("version " + Program.Version, ConsoleColor.Yellow)
            .NextLine();

        RegisterHelp();
        RegisterCommand("exit", "Exits the application with code 0", _ => Environment.Exit(0));
        RegisterCommand("clear", "Clears the console", _ =>
        {
            Console.Clear();
            Write("PartyPlayer", ConsoleColor.Magenta)
                .Space()
                .Write("version " + Program.Version, ConsoleColor.Yellow)
                .NextLine();
        });

        new Thread(ReadConsole).Start();
    }

    public static bool Start()
    {
        if (Manager != null) return false;

        Manager = new ConsoleManager();
        return true;
    }

    public ConsoleManager Write(string text, ConsoleColor textColor = ConsoleColor.White,
        ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        lock (_messageLock)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(text);
            Console.ResetColor();
        }

        return this;
    }

    public ConsoleManager Space()
    {
        Write(" ");
        return this;
    }

    public ConsoleManager NextLine()
    {
        Console.WriteLine();
        return this;
    }

    private void ReadConsole()
    {
        while (!End)
        {
            try
            {
                var raw = Console.ReadLine()?.ToLower().Trim();
                if (raw == null || string.IsNullOrEmpty(raw)) continue;

                ParseCommand(raw);
            }
            catch (IOException)
            {
                break;
            }
        }
    }

    private void ParseCommand(string rawCommand)
    {
        var fullMatch = FullPattern.Match(rawCommand);

        if (!fullMatch.Success)
        {
            Write("Invalid command format", ConsoleColor.Red).NextLine();
            return;
        }

        var command = fullMatch.Groups[1].Value;

        if (!_commands.ContainsKey(command))
        {
            Write("Unknown command", ConsoleColor.Red)
                .Space()
                .Write(command, ConsoleColor.White, ConsoleColor.Red)
                .NextLine();
            return;
        }

        var wrapper = _commands[command]!;
        var argsGroup = fullMatch.Groups.Count > 1 ? fullMatch.Groups[2] : null;
        var argsDict = new Dictionary<string, string>();
        if (argsGroup != null)
            foreach (var match in ArgumentPattern.Matches(argsGroup.Value))
            {
                if (match is not Match argMatch) continue;


                if (wrapper.AllowedArguments.Any() && !wrapper.AllowedArguments.Contains(argMatch.Groups[1].Value))
                {
                    wrapper.Log("Invalid argument '" + argMatch.Groups[1].Value + "'");
                    return;
                }

                if (argsDict.ContainsKey(argMatch.Groups[1].Value))
                {
                    wrapper.Log("You have inputted the same argument more than once.");
                    return;
                }

                argsDict[argMatch.Groups[1].Value] = argMatch.Groups.Count == 1 ? null :
                    string.IsNullOrEmpty(argMatch.Groups[2].Value) ? argMatch.Groups[3].Value :
                    argMatch.Groups[2].Value;
            }

        if (wrapper.RequireOneArgument && argsDict.Count == 0)
        {
            wrapper.ShowHelp();
            return;
        }

        wrapper.Action.Invoke(new CommandEvent(wrapper, argsDict));
    }

    public Command RegisterCommand(string name, string description, Action<CommandEvent> action,
        params string[] allowedArguments)
    {
        name = name.ToLower();

        if (_commands.ContainsKey(name)) throw new ArgumentException("Command '" + name + "' is already registered");
        var command = new Command(name, description, new List<string>(allowedArguments), Array.Empty<string>(),
            action);
        _commands[name] = command;
        return command;
    }

    private void RegisterHelp()
    {
        const string name = "help";
        const string description = "Shows a list of all commands";
        var help = new[] { "help -<command name>" };

        void Action(CommandEvent e)
        {
            if (!e.Arguments.Any())
            {
                Manager.Write(@"------------------------------------").NextLine()
                    .Write(@"List of commands:").NextLine()
                    .Write(@"Do 'help -<command name>' for further information about a command").NextLine();
                foreach (var pair in _commands)
                    Manager.Write(pair.Key, ConsoleColor.Black, ConsoleColor.Yellow)
                        .Space()
                        .Write(pair.Value.Description ?? "No help for this command").NextLine();

                Manager.Write(@"------------------------------------").NextLine();
                return;
            }

            if (e.Arguments.Count > 1)
            {
                e.Reply("Too many arguments. Do 'help' for more information");
                return;
            }

            var c = e.Arguments.Keys.First().ToLower();

            if (_commands.ContainsKey(c))
                _commands[c].ShowHelp();
            else
                e.Reply("Unknown command '" + c + "'");
        }

        RegisterCommand(name, description, Action).SetHelp(help);
    }

    public class Command
    {
        public readonly Action<CommandEvent> Action;
        public readonly List<string> AllowedArguments;
        public readonly string Description;
        public readonly string Name;
        public string[] Help;
        internal bool RequireOneArgument;

        protected internal Command(string name, string description, List<string> allowedArguments, string[] help,
            Action<CommandEvent> action)
        {
            Name = name;
            Description = description;
            AllowedArguments = allowedArguments;
            Help = help;
            Action = action;
        }

        public void Log(string message)
        {
            Manager.Write(Name, ConsoleColor.Black, ConsoleColor.Yellow)
                .Space()
                .Write(message)
                .NextLine();
        }

        public Command SetHelp(params string[] help)
        {
            Help = help;
            return this;
        }

        public void ShowHelp()
        {
            Manager.Write(@"------------------------------------").NextLine();

            if (Help.Any())
                foreach (var line in Help)
                    Manager.Write(line, ConsoleColor.Yellow).NextLine();
            else
                Manager.Write(@"No help for this command", ConsoleColor.Red).NextLine();

            Manager.Write(@"------------------------------------").NextLine();
        }

        public Command RequireArgument()
        {
            RequireOneArgument = true;
            return this;
        }
    }

    public class CommandEvent
    {
        public readonly Dictionary<string, string> Arguments;
        public readonly Command Command;

        public CommandEvent(Command command, Dictionary<string, string> arguments)
        {
            Command = command;
            Arguments = arguments;
        }

        public void Reply(string message)
        {
            Command.Log(message);
        }

        public string RequestInput(string name)
        {
            if (!string.IsNullOrEmpty(name)) Manager.Write(name + @": ", ConsoleColor.Yellow);

            return Console.ReadLine() ?? string.Empty;
        }

        public string RequestInput(string name, Func<string, bool> validationPolicy, bool repeatUntilValid)
        {
            if (!string.IsNullOrEmpty(name)) Manager.Write(name + @": ", ConsoleColor.Yellow);

            var input = Console.ReadLine() ?? string.Empty;

            if (repeatUntilValid && input.Equals("cancel")) return null;

            if (validationPolicy.Invoke(input)) return input;

            if (repeatUntilValid) return RequestInput(name, validationPolicy, true);

            return null;
        }

        public string RequestInput(string name, ValidationPolicy validationPolicy, bool showHint = true,
            bool repeatUntilValid = false)
        {
            if (!string.IsNullOrEmpty(name))
                Manager.Write(name + @"(" + (showHint ? validationPolicy.Hint : "") + @"): ", ConsoleColor.Yellow);

            var input = Console.ReadLine() ?? string.Empty;

            if (repeatUntilValid && input.Equals("cancel")) return null;

            if (validationPolicy.Policy.Invoke(input)) return input;

            if (repeatUntilValid) return RequestInput(name, validationPolicy, showHint, true);

            return null;
        }
    }

    public class ValidationPolicy
    {
        public static ValidationPolicy Integer = Create(input => int.TryParse(input, out _), "int");
        public static ValidationPolicy Float = Create(input => float.TryParse(input, out _), "float");
        public readonly string Hint;
        public readonly Func<string, bool> Policy;

        private ValidationPolicy(Func<string, bool> policy, string hint)
        {
            Policy = policy;
            Hint = hint;
        }

        public static ValidationPolicy Create(Func<string, bool> policy, string hint)
        {
            return new ValidationPolicy(policy, hint);
        }
    }
}