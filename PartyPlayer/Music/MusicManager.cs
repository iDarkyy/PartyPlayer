using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NAudio.Extras;
using NAudio.Wave;
using PartyPlayer.Configuration;
using PartyPlayer.Utils;

namespace PartyPlayer.Music;

public class MusicManager : IDisposable
{
    public enum AutomationQueuePosition
    {
        First,
        Last
    }

    private static readonly Logger Logger = Logger.Create("Music");
    private static readonly Random Random = new();

    public readonly ListQueue<Song> Queue = new();
    public readonly List<Song.RequestedSong> RequestedSongs = new();
    public readonly SongSources SongSources;
    public bool AutoAcceptRequestedSongs = false;

    // settings
    public readonly EqualizerBand[] EqualizerBands;
    public bool PlayRandomSongsIfQueueIsEmpty = true;
    public bool Repeat = false;
    public AutomationQueuePosition RequestAutomationQueuePosition = AutomationQueuePosition.Last;
    public bool Shuffle = false;

    public MusicManager(ConfigurationManager<Configuration.Configuration> configurationManager)
    {
        SongSources = new SongSources(configurationManager);
        WaveOutEvent = new WaveOutEvent();

        // events
        WaveOutEvent.PlaybackStopped += OnPlaybackStopped;

        // equalizer defaults
        EqualizerBands = new EqualizerBand[]
        {
            new() { Bandwidth = 0.8f, Frequency = 100, Gain = 0 },
            new() { Bandwidth = 0.8f, Frequency = 200, Gain = 0 },
            new() { Bandwidth = 0.8f, Frequency = 400, Gain = 0 },
            new() { Bandwidth = 0.8f, Frequency = 800, Gain = 0 },
            new() { Bandwidth = 0.8f, Frequency = 1200, Gain = 0 },
            new() { Bandwidth = 0.8f, Frequency = 2400, Gain = 0 },
            new() { Bandwidth = 0.8f, Frequency = 4800, Gain = 0 },
            new() { Bandwidth = 0.8f, Frequency = 9600, Gain = 0 }
        };
    }

    public WaveOutEvent WaveOutEvent { get; }
    public AudioFileReader CurrentAudioFile { get; private set; }
    public Equalizer Equalizer { get; private set; }

    public void Dispose()
    {
        WaveOutEvent?.Dispose();
        CurrentAudioFile?.Dispose();
    }

    public void Play()
    {
        if (WaveOutEvent.PlaybackState != PlaybackState.Paused) return;
        
        WaveOutEvent.Play();
        OnPauseChange?.Invoke(this, false);
    }

    public void Play(Song song)
    {
        // if the song is same setting the position to 0
        if (CurrentAudioFile?.FileName == song.FilePath)
        {
            CurrentAudioFile!.Position = 0;
            WaveOutEvent.Play();
            return;
        }

        // if something else is playing stopping the playback and disposing of the old reader
        BlockUntilStopped(); // this method blocks the thread until playback has been stopped
        CurrentAudioFile?.Dispose();
        CurrentAudioFile = null;

        // creating new reader and applying equalizer
        CurrentAudioFile = new AudioFileReader(song.FilePath);
        Equalizer = new Equalizer(CurrentAudioFile, EqualizerBands);

        // starting playback
        WaveOutEvent.Init(Equalizer);
        WaveOutEvent.Play();
        OnMediaPlay?.Invoke(this, song);
    }

    public void PlayNext()
    {
        if (Queue.Any())
        {
            if (Shuffle)
                Play(Queue.Count == 1 ? Queue.Dequeue() : Queue.Dequeue(Random.Next(Queue.Count)));
            else
                Play(Queue.Dequeue());
        }
        else
        {
            if (PlayRandomSongsIfQueueIsEmpty) Play(SongSources.RandomSong());
        }
    }

    public void AddRequestedSong(Song.RequestedSong song)
    {
        if (AutoAcceptRequestedSongs)
        {
            if (RequestAutomationQueuePosition == AutomationQueuePosition.First)
                Queue.EnqueueNext(song);
            else
                Queue.Enqueue(song);
        }
        else
        {
            RequestedSongs.Add(song);
            OnSongRequest?.Invoke(this, song);
        }
        
        
    }

    public bool HasNext()
    {
        return Queue.Any() || PlayRandomSongsIfQueueIsEmpty;
    }

    public void PlayPrevious()
    {
        // TODO
    }

    public void Pause()
    {
        if (WaveOutEvent.PlaybackState == PlaybackState.Playing)
        {
            WaveOutEvent.Pause();
            OnPauseChange?.Invoke(this, true);
        }
    }

    private void OnPlaybackStopped(object sender, StoppedEventArgs e)
    {
        if (e.Exception != null)
        {
            MessageBox.Show(
                @"A Music error occurred. Check the console for details. " + Environment.NewLine + e.Exception,
                @"MusicManager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Logger.Error("An error occurred which caused the WaveOutEvent to stop", e.Exception);
            OnMediaEnd?.Invoke(this, new SongEndEventArgs(SongEndReason.Exception, false, e.Exception));
            return;
        }

        // checking if repeat is enabled, and playing the audio again if it is
        if (Repeat)
        {
            CurrentAudioFile.Position = 0;
            WaveOutEvent.Play();
            return;
        }


        // checking if the song ended naturally
        if (Math.Abs(CurrentAudioFile.CurrentTime.TotalSeconds - CurrentAudioFile.TotalTime.TotalSeconds) < 1)
        {
            OnMediaEnd?.Invoke(this, new SongEndEventArgs(SongEndReason.EndedNaturally, HasNext()));
            PlayNext();
        }

        OnMediaEnd?.Invoke(this, new SongEndEventArgs(SongEndReason.EndedNaturally, HasNext()));
    }

    private void BlockUntilStopped()
    {
        WaveOutEvent.Stop();
        while (WaveOutEvent.PlaybackState != PlaybackState.Stopped)
        {
        }
    }

    #region Events

    public delegate void MediaPlayHandler(MusicManager sender, Song song);

    public delegate void MediaEndHandler(MusicManager sender, SongEndEventArgs eventArgs);

    public delegate void PauseChangeHandler(MusicManager sender, bool newState);

    public delegate void RequestAddHandler(MusicManager sender, Song.RequestedSong requestedSong);

    public event MediaPlayHandler OnMediaPlay;
    public event MediaEndHandler OnMediaEnd;
    public event PauseChangeHandler OnPauseChange;
    public event RequestAddHandler OnSongRequest;


    public class SongEndEventArgs : EventArgs
    {
        public readonly SongEndReason EndReason;
        public readonly Exception Exception;
        public readonly bool HasNext;

        public SongEndEventArgs(SongEndReason endReason, bool hasNext, Exception exception = null)
        {
            HasNext = hasNext;
            Exception = exception;
            EndReason = endReason;
        }
    }

    public enum SongEndReason
    {
        Exception,
        EndedNaturally
    }

    #endregion
}