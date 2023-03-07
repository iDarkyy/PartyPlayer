using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FontAwesome.Sharp;
using MaterialSkin;
using NAudio.Wave;
using PartyPlayer.Configuration;
using PartyPlayer.Music;
using PartyPlayer.Server;
using PartyPlayer.Utils;

namespace PartyPlayer.Forms;

public partial class MainForm : Form
{
    public readonly Logger Logger = Logger.Create("Main");
    public readonly ConfigurationManager<Configuration.Configuration> ConfigurationManager;
    public readonly MusicManager MusicManager;
    public readonly MusicServer MusicServer;
    
    // form
    private readonly Panel _buttonBorder;
    private IconButton _currentButton;
    private Form _currentChildForm;

    public MainForm()
    {
        InitializeComponent();

        // initializing the configuration
        try
        {
            ConfigurationManager = new ConfigurationManager<Configuration.Configuration>(new Configuration.Configuration
            {
                UseConsole = false,
                Debug = false,
                SourceFolders = new List<string>(),
                SkipSongsShorterThan = 60,
                SkipSongsLongerThan = 300,
                UseSongRequestServer = false,
                SongServerHost = "127.0.0.1",
                SongServerPort = 6969
            });
        }
        catch (Exception e)
        {
            // if loading the config throws an exception
            MessageBox.Show(e.Message, @"An error occurred while loading the configuration", MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            //Logger.Error("An error occurred while loading the configuration", e);

            Application.Exit();
            return;
        }

        // enabling console if needed
        if (ConfigurationManager.Configuration.UseConsole)
        {
            AllocConsole();
            Logger.ShowDebugMessages = ConfigurationManager.Configuration.Debug;
            ConsoleManager.Start();
            RegisterCommands();
        }

        // initializing music manager
        MusicManager = new MusicManager(ConfigurationManager);
        MusicManager.SongSources.Reload();
        MusicManager.WaveOutEvent.Volume = 0.5f; // default volume

        // style
        menuPanel.GenerateGradient(playbackPanel, DockStyle.Bottom, preferredY: 5);

        _buttonBorder = new Panel();
        _buttonBorder.Size = queueButton.Size with { Width = 2 };
        _buttonBorder.BackColor = Style.Colors.PrimaryColor;
        menuPanel.Controls.Add(_buttonBorder);

        var materialColorScheme = new ColorScheme(Style.Colors.PrimaryColor, Style.Colors.PrimaryColor,
            Style.Colors.PrimaryColor, Style.Colors.PrimaryColor, TextShade.WHITE);
        songPositionSlider.SkinManager.ColorScheme = materialColorScheme;
        volumeSlider.SkinManager.ColorScheme = materialColorScheme;
        
        // opening default (landing) page
        ActivateButton(queueButton);
        OpenChildForm(new QueueForm(this));

        // registering events
        MusicManager.OnMediaPlay += OnMediaPlay;
        MusicManager.OnMediaEnd += OnMediaEnd;

        // applying slider controls
        MaterialTrackbarUpdater.Start(MusicManager, songPositionSlider, songPositionLabel);
        
        // starting server if needed
        if (ConfigurationManager.Configuration.UseSongRequestServer)
        {
            IPAddress ipAddress;
            if (!IPAddress.TryParse(ConfigurationManager.Configuration.SongServerHost, out ipAddress))
            {
                MessageBox.Show(@"Invalid IP address in configuration" + 
                                Environment.NewLine + @"You can modify it in the Settings page, or the configuration file");
                return;
            }

            var port = ConfigurationManager.Configuration.SongServerPort;
            if (port is < 0 or > 65536)
            {
                MessageBox.Show(@"Invalid port in configuration (must be between 0 and 65536)" + 
                                Environment.NewLine + @"You can modify it in the Settings page, or the configuration file");
                return;
            }

            MusicServer = new MusicServer(MusicManager, new IPEndPoint(ipAddress, port));
            // TODO server client listeners
        }

        Logger.Info("Application loaded!");
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool AllocConsole();

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool FreeConsole();

    #region Form events

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        ConsoleManager.End = true;
        FreeConsole();
        MusicManager.Dispose();
        // todo Dispose music server
    }

    private void queueButton_Click(object sender, EventArgs e)
    {
        if (_currentButton == sender) return;

        ActivateButton(sender);
        OpenChildForm(new QueueForm(this));
    }

    private void libraryButton_Click(object sender, EventArgs e)
    {
        if (_currentButton == sender) return;

        ActivateButton(sender);
        OpenChildForm(new LibraryForm(this));
    }

    private void requestsButton_Click(object sender, EventArgs e)
    {
        if (_currentButton == sender) return;

        ActivateButton(sender);
        OpenChildForm(new SongRequestsForm(this));
    }

    private void equalizerButton_Click(object sender, EventArgs e)
    {
        if (_currentButton == sender) return;

        ActivateButton(sender);
        OpenChildForm(new EqualizerForm(this));
    }

    private void settingsButton_Click(object sender, EventArgs e)
    {
        if (_currentButton == sender) return;

        ActivateButton(sender);
        OpenChildForm(new SettingsForm(this));
    }

    private void playButton_Click(object sender, EventArgs e)
    {
        switch (MusicManager.WaveOutEvent.PlaybackState)
        {
            // if a song is playing we pause it
            case PlaybackState.Playing:
                MusicManager.Pause();
                playButton.IconChar = IconChar.Play;
                break;
            
            // if the song is paused we play it
            case PlaybackState.Paused:
                MusicManager.Play();
                playButton.IconChar = IconChar.Pause;
                break;
            
            // if no song is playing we prompt the user to play it or play a random songs (according to the settings)
            case PlaybackState.Stopped:
            default:
            {
                if (!MusicManager.Queue.Any())
                {
                    if (MusicManager.PlayRandomSongsIfQueueIsEmpty)
                    {
                        // if there is no songs loaded we prompt the user to add some source directories
                        if (MusicManager.SongSources.Songs.Count == 0)
                            MessageBox.Show(@"No songs found. Add a folder in the library", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        else
                            MusicManager.PlayNext();
                    }
                    else
                    {
                        // if playing random songs if disabled we prompt the user to play a song directly from the library
                        MessageBox.Show(@"Play a song from the Library", @"No song currently playing", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        // opening library page
                        ActivateButton(sender);
                        OpenChildForm(new LibraryForm(this));
                    }
                }

                break;
            }
        }
    }

    private void forwardButton_Click(object sender, EventArgs e)
    {
        MusicManager.PlayNext();
    }

    private void backwardButton_Click(object sender, EventArgs e)
    {
        MusicManager.PlayPrevious();
    }

    private void repeatButton_Click(object sender, EventArgs e)
    {
        MusicManager.Repeat = !MusicManager.Repeat;
        repeatButton.IconColor = MusicManager.Repeat ? Style.Colors.MediaButtonOn : Style.Colors.MediaButtonOff;
    }

    private void shuffleButton_Click(object sender, EventArgs e)
    {
        MusicManager.Shuffle = !MusicManager.Shuffle;
        shuffleButton.IconColor = MusicManager.Repeat ? Style.Colors.MediaButtonOn : Style.Colors.MediaButtonOff;
    }

    private void volumeSlider_onValueChanged(object sender, int newValue)
    {
        MusicManager.WaveOutEvent.Volume = newValue / 100f;
        volumeLabel.Text = newValue + @"%";
    }

    #endregion
    
    #region Media events

    private void OnMediaPlay(MusicManager musicManager, Song song)
    {
        songNameLabel.Text = song.Name;
        songAuthorLabel.Text = song.Author;
        songLengthLabel.Text = MusicManager.CurrentAudioFile.TotalTime.ToString("mm':'ss");
        playButton.IconChar = IconChar.Pause;
    }

    private void OnMediaEnd(MusicManager musicManager, MusicManager.SongEndEventArgs e)
    {
        if (e.HasNext) return;
        
        songNameLabel.Text = string.Empty;
        songAuthorLabel.Text = string.Empty;
        songPositionLabel.Text = @"00:00";
        songLengthLabel.Text = @"00:00";
        playButton.IconChar = IconChar.Play;
    }
    
    #endregion

    #region Form methods

    private void ActivateButton(object senderButton)
    {
        if (senderButton == null || _currentButton == senderButton) return;

        DisableButton();
        _currentButton = (IconButton)senderButton;
        _currentButton.BackColor = Style.Colors.ActiveButtonBackgroundColor;

        // left border button
        _buttonBorder.Location =
            _currentButton.Location with { X = 0 };
        _buttonBorder.Visible = true;
        _buttonBorder.BringToFront();
    }

    private void DisableButton()
    {
        if (_currentButton == null) return;

        _currentButton.BackColor = Style.Colors.InactiveButtonBackgroundColor;
    }

    private void OpenChildForm(Form childForm)
    {
        _currentChildForm?.Close();

        _currentChildForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        desktopPanel.Controls.Add(childForm);
        desktopPanel.Tag = childForm;
        childForm.BringToFront();
        childForm.Show();
    }

    #endregion
}