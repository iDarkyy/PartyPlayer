using System.Linq;

namespace PartyPlayer.Forms;

public partial class MainForm
{
    private void RegisterCommands()
    {
        var cm = ConsoleManager.Manager;

        cm.RegisterCommand("debug", "Whether or not debug messages will be shown", @event =>
        {
            if (@event.Arguments.Count == 0 || @event.Arguments.ContainsKey("status"))
            {
                @event.Reply("Debug is currently " + (Logger.ShowDebugMessages ? "enabled" : "disabled"));
                return;
            }


            if (@event.Arguments.Count > 1)
            {
                @event.Reply("Too many arguments");
                return;
            }

            var arg = @event.Arguments.First().Key;
            var currentStatus = Logger.ShowDebugMessages;
            ConfigurationManager.Configuration.Debug = false;
            ConfigurationManager.Save();

            switch (arg)
            {
                case "on" or "enable" when currentStatus:
                    @event.Reply("Debug is already enabled");
                    return;
                case "on" or "enable":
                    Logger.ShowDebugMessages = true;
                    ConfigurationManager.Configuration.Debug = true;
                    ConfigurationManager.Save();
                    @event.Reply("Debug has been enabled");
                    break;
                case "off" or "disable" when !currentStatus:
                    @event.Reply("Debug is already disabled");
                    return;
                case "off" or "disable":
                    Logger.ShowDebugMessages = false;
                    @event.Reply("Debug has been disabled");
                    break;
            }
        }, "on", "off", "status").SetHelp(
            "debug [-status] -> Shows whether debug is enabled",
            "debug -on -> Enables (shows) debug messages",
            "debug -off -> Disables (no longer shows) debug messages"
        );
    }
}