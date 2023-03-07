using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PartyPlayer.Configuration;

namespace PartyPlayer.Music;

public class SongSources
{
    private static Random Random = new();
    private static Logger Logger = Logger.Create("SongSources");

    private static readonly List<string> SupportedFileTypes = new()
    {
        ".mp3",
        ".wav",
        ".aif",
        ".aiff",
        ".wma",
        ".aac",
        ".mp4"
    };

    private readonly ConfigurationManager<Configuration.Configuration> _configurationManager;
    public readonly List<Song> Songs = new();

    public SongSources(ConfigurationManager<Configuration.Configuration> configurationManager)
    {
        _configurationManager = configurationManager;
    }

    public void Reload()
    {
        Songs.Clear();
        foreach (var dir in _configurationManager.Configuration.SourceFolders.Where(Directory.Exists)) Load(dir);
    }

    private void Load(string dir)
    {
        foreach (var file in Directory.GetFiles(dir))
        {
            var song = new Song(file);
            if (!SupportedFileTypes.Contains(Path.GetExtension(file))) continue;
            if (song.Length.TotalSeconds > _configurationManager.Configuration.SkipSongsLongerThan) continue;
            if (song.Length.TotalSeconds < _configurationManager.Configuration.SkipSongsShorterThan) continue;
            
            Songs.Add(song);
        }

        Logger.Debug("Loaded " + Songs.Count + " songs");
    }

    public string ToJsonString()
    {
        var builder = new StringBuilder("{");

        for (var i = 0; i < Songs.Count; i++)
        {
            var song = Songs[i];
            builder.Append('"').Append(i).Append('"').Append(':');
            builder.Append('{');

            builder.Append('"').Append("Name").Append("\":\"").Append(song.Name).Append("\",");
            builder.Append('"').Append("Location").Append("\":\"").Append(song.FilePath).Append("\",");
            builder.Append('"').Append("Duration").Append("\":").Append(song.Length.TotalMilliseconds);

            builder.Append('}');
            if (i != Songs.Count - 1)
            {
                builder.Append(',');
            }
        }

        return builder.ToString();
    }
    
    public Song RandomSong()
    {
        return Songs[Random.Next(Songs.Count)];
    }
}