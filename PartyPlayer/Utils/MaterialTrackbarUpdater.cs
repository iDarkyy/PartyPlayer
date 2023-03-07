using System;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin.Controls;
using NAudio.Wave;
using PartyPlayer.Music;
using Exception = System.Exception;

namespace PartyPlayer.Utils;

public class MaterialTrackbarUpdater
{
    private const int Delay = 100;
    private readonly Label _currentTimeLabel;
    private readonly MusicManager _musicManager;
    private readonly MaterialSlider _slider;
    private bool _mouseDown;
    private float _newValue;
    private bool _stop = false;

    private MaterialTrackbarUpdater(MusicManager musicManager, MaterialSlider slider, Label currentTimeLabel)
    {
        _musicManager = musicManager;
        _slider = slider;
        _currentTimeLabel = currentTimeLabel;

        _slider.ValueMax = 100;

        slider.MouseDown += OnTrackbarPress;
        slider.MouseUp += OnTrackbarRelease;
        slider.onValueChanged += OnTrackbarValueChange;
        slider.FindForm()!.FormClosing += (_, _) =>
        {
            _stop = true;
        };

        new Thread(_ =>
        {
            while (!_stop)
            {
                try
                {
                    if (_musicManager.WaveOutEvent == null) break;
                    slider.PerformSafely(Update);
                    Thread.Sleep(Delay);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }).Start();
    }

    private void OnTrackbarPress(object sender, MouseEventArgs e)
    {
        _mouseDown = true;
    }

    private void OnTrackbarRelease(object sender, MouseEventArgs e)
    {
        _mouseDown = false;
        var file = _musicManager.CurrentAudioFile;
        if (file == null) return;

        file.Position = (long)Denormalize(0, file.Length, _newValue);
    }

    private void OnTrackbarValueChange(object sender, int newValue)
    {
        var file = _musicManager.CurrentAudioFile;
        if (file == null) return;

        _newValue = newValue / 100f;
        _currentTimeLabel.Text = TimeSpan
            .FromSeconds(Denormalize(0, (float)file.TotalTime.TotalSeconds, _newValue))
            .ToString("mm':'ss");
    }

    private void Update()
    {
        if (_musicManager.WaveOutEvent == null!) return;
        _slider.Enabled = _musicManager.WaveOutEvent.PlaybackState != PlaybackState.Stopped;
        if (_mouseDown) return;
        var file = _musicManager.CurrentAudioFile;
        if (file == null) return;

        var timespan = file.CurrentTime;
        _slider.Value = (int)NormalizeHundred(0, (float)file.TotalTime.TotalSeconds, (float)timespan.TotalSeconds);
        _currentTimeLabel.Text = timespan.ToString("mm':'ss");
    }

    private static float NormalizeHundred(float min, float max, float value)
    {
        return (value - min) / (max - min) * 100;
    }

    private static float Denormalize(float min, float max, float value)
    {
        return value * (max - min) + min;
    }

    public static void Start(MusicManager musicManager, MaterialSlider slider, Label timeLabel)
    {
        // not saving the variable because it will most likely not be needed
        var materialTrackbarUpdater = new MaterialTrackbarUpdater(musicManager, slider, timeLabel);
    }
}