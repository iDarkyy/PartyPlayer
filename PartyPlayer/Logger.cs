using System;

namespace PartyPlayer;

public class Logger
{
    public static bool ShowDebugMessages;
    public static readonly Logger Global = Create("Global");

    private Logger(string service)
    {
        Service = service;
    }

    public string Service { get; set; }

    public void Info(string message)
    {
        WriteTimePrefix()?.Write($"[{Service}/INFO]", ConsoleColor.Cyan).Space().Write(message).NextLine();
    }

    public void Debug(string message)
    {
        if (!ShowDebugMessages) return;
        WriteTimePrefix()?.Write($"[{Service}/DEBUG]", ConsoleColor.Yellow).Space().Write(message, ConsoleColor.Yellow)
            .NextLine();
    }

    public void Warning(string message)
    {
        WriteTimePrefix()?.Write($"[{Service}/WARNING]", ConsoleColor.Red).Space().Write(message, ConsoleColor.Red)
            .NextLine();
    }

    public void Error(string message)
    {
        WriteTimePrefix()?.Write($"[{Service}/ERROR] " + message, ConsoleColor.White, ConsoleColor.Red).NextLine();
    }

    public void Error(string message, Exception exception)
    {
        WriteTimePrefix()?.Write($"[{Service}/ERROR EXCEPTION] " + message, ConsoleColor.White, ConsoleColor.Red)
            .NextLine();

        if (exception != null)
            ConsoleManager.Manager.Write(exception.ToString(), ConsoleColor.White, ConsoleColor.Red).NextLine();
    }

    private static ConsoleManager WriteTimePrefix(ConsoleColor textColor = ConsoleColor.White,
        ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        var date = DateTime.Now;
        return ConsoleManager.Manager?.Write($"{date.ToShortDateString()} {date.ToShortTimeString()}",
            textColor, backgroundColor).Space();
    }

    public static Logger Create(string serviceName)
    {
        return new Logger(serviceName);
    }
}