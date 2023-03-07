using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Forms;
using NAudio.Extras;
using Label = System.Windows.Forms.Label;
using Orientation = System.Windows.Forms.Orientation;

namespace PartyPlayer.Forms;

public partial class EqualizerForm : Form
{
    public MainForm MainForm { get; }

    private const int GainBounds = 12;
    private const bool UpdateEqualizerImmediately = true;

    public EqualizerForm(MainForm mainForm)
    {
        MainForm = mainForm;
        InitializeComponent();
        
        CreateSliders();
    }

    private void CreateSliders()
    {
        var musicManager = MainForm.MusicManager;
        var labelPadding = new Padding(5, 0, 0, 0);
        
        foreach (var band in musicManager.EqualizerBands)
        {

            // creating slider
            var slider = new TrackBar
            {
                Maximum = GainBounds,
                Minimum = -GainBounds,
                Value = (int) band.Gain,
                Dock = DockStyle.Left,
                Orientation = Orientation.Vertical
            };

            slider.ValueChanged += (_, _) =>
            {
                band.Gain = slider.Value;

                if (UpdateEqualizerImmediately) ApplyEqualizer();
            };
            
            Controls.Add(slider);
            
            // creating label
            var label = new Label()
            {
                Text = band.Frequency.ToString(CultureInfo.InvariantCulture),
                Dock = DockStyle.Bottom,
                Padding = labelPadding
            };
            
            slider.Controls.Add(label);
        }
    }

    private void ApplyEqualizer()
    {
        MainForm.MusicManager.Equalizer?.Update();
    }
}