using System;
using System.Windows.Forms;
using PartyPlayer.Forms;

namespace PartyPlayer;

internal static class Program
{
    public const string Version = "1.0";

    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}