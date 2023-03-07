using System.Drawing;

namespace PartyPlayer.Forms;

public class Style
{
    public struct Fonts
    {
        public static readonly Font QueueSongPosition = new("Microsoft Sans Serif", 15f, FontStyle.Regular);
        public static readonly Font SongName = new("Microsoft Sans Serif", 9f, FontStyle.Bold);
        public static readonly Font SongAuthors = new("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        public static readonly Font Requester = new("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        public static readonly Font DirectoryPath = new("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
    }

    public struct Brushes
    {
        public static readonly SolidBrush QueueSongPosition = new(Color.FromArgb(240, 240, 240));
        public static readonly SolidBrush SongName = new(Color.FromArgb(230, 75, 75));
        public static readonly SolidBrush SongAuthors = new(Color.FromArgb(200, 200, 200));
        public static readonly SolidBrush Requester = new(Color.FromArgb(230, 75, 75));
        public static readonly SolidBrush Directory = new(Color.FromArgb(255, 255, 255));
    }

    public struct Colors
    {
        public static readonly Color ListBoxSelectedBackground = Color.FromArgb(70, 70, 70);
        public static readonly Color PrimaryColor = Color.FromArgb(255, 75, 75);
        public static readonly Color InactiveButtonBackgroundColor = Color.FromArgb(60, 60, 60);
        public static readonly Color ActiveButtonBackgroundColor = Color.FromArgb(100,100,100);
        public static readonly Color MediaButtonOn = Color.FromArgb(255, 255, 0);
        public static readonly Color MediaButtonOff = Color.FromArgb(170, 170, 170);
    }
}