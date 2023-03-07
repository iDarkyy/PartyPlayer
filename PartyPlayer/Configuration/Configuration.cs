using System.Collections.Generic;

namespace PartyPlayer.Configuration;

public class Configuration
{
    public List<string> SourceFolders = new();
    public bool UseConsole { get; set; }

    public bool Debug { get; set; }
    public int SkipSongsShorterThan { get; set; }
    public int SkipSongsLongerThan { get; set; }
    public bool UseSongRequestServer { get; set; }
    public string SongServerHost { get; set; }
    public int SongServerPort { get; set; }
}