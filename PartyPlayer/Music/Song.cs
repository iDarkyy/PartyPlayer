using System;
using System.Drawing;
using System.IO;

namespace PartyPlayer.Music;

public class Song
{
    public Song(string filePath)
    {
        if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

        FilePath = filePath;
        var file = TagLib.File.Create(FilePath);

        Name = file.Tag.Title ?? Path.GetFileNameWithoutExtension(filePath);
        Author = file.Tag.JoinedAlbumArtists ?? "Unknown artist(s)";
        Length = file.Properties.Duration;
        Icon = null; // TODO

        file.Dispose();
    }

    public string FilePath { get; }
    public string Name { get; }
    public string Author { get; }

    public Image Icon { get; }

    public TimeSpan Length { get; }

    public override bool Equals(object obj)
    {
        if (obj is Song song) return song.FilePath == FilePath;
        return false;
    }

    public RequestedSong CreateRequestedSong(string requester)
    {
        return new RequestedSong(requester, FilePath);
    }
    
    protected bool Equals(Song other)
    {
        return FilePath == other.FilePath;
    }

    public override int GetHashCode()
    {
        return FilePath.GetHashCode();
    }

    public class RequestedSong : Song
    {
        public readonly string Requester;

        public RequestedSong(string requester, string filePath) : base(filePath)
        {
            Requester = requester;
        }

        public override bool Equals(object obj)
        {
            if (obj is Song song)
            {
                return FilePath == song.FilePath;
            }

            return false;
        }

        protected bool Equals(RequestedSong other)
        {
            return base.Equals(other) && Requester == other.Requester;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (Requester != null ? Requester.GetHashCode() : 0);
            }
        }
    }
}