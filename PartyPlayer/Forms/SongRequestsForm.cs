using System;
using System.Windows.Forms;
using PartyPlayer.Music;

namespace PartyPlayer.Forms;

public partial class SongRequestsForm : Form
{
    public MainForm MainForm { get; }

    private bool AutoAcceptSongs
    {
        get => MainForm.MusicManager.AutoAcceptRequestedSongs;
        set => MainForm.MusicManager.AutoAcceptRequestedSongs = value;
    }

    private MusicManager.AutomationQueuePosition AutomationQueuePosition
    {
        get => MainForm.MusicManager.RequestAutomationQueuePosition;
        set => MainForm.MusicManager.RequestAutomationQueuePosition = value;
    }

    public SongRequestsForm(MainForm mainForm)
    {
        MainForm = mainForm;
        InitializeComponent();

        autoAcceptSwitch.Checked = AutoAcceptSongs;
        addToSongGroupBox.Enabled = AutoAcceptSongs;

        if (AutomationQueuePosition == MusicManager.AutomationQueuePosition.First)
        {
            autoFrontRadioButton.Checked = true;
            autoEndRadioButton.Checked = false;
        }
        else
        {
            autoFrontRadioButton.Checked = false;
            autoEndRadioButton.Checked = true;
        }

        foreach (var requestedSong in MainForm.MusicManager.RequestedSongs)
        {
            requestsListBox.Items.Add(requestedSong);
        }
    }


    #region Actions
    private bool ShowSelectionError()
    {
        if (requestsListBox.SelectedIndex != -1) return false;
        MessageBox.Show(@"No song request has been selected", @"Selection error", MessageBoxButtons.OK,
            MessageBoxIcon.Error);

        return true;
    }

    private void PlayNowAction(object sender, EventArgs e)
    {
        if (ShowSelectionError()) return;

        var selectedIndex = requestsListBox.SelectedIndex;
        var song = MainForm.MusicManager.RequestedSongs[selectedIndex];

        MainForm.MusicManager.Play(song);
        
        MainForm.MusicManager.RequestedSongs.RemoveAt(selectedIndex);
        requestsListBox.Items.RemoveAt(selectedIndex);
    }

    private void PlayNextAction(object sender, EventArgs e)
    {
        if (ShowSelectionError()) return;

        var selectedIndex = requestsListBox.SelectedIndex;
        var song = MainForm.MusicManager.RequestedSongs[selectedIndex];

        MainForm.MusicManager.Queue.EnqueueNext(song);
        
        MainForm.MusicManager.RequestedSongs.RemoveAt(selectedIndex);
        requestsListBox.Items.RemoveAt(selectedIndex);
    }

    private void EnqueueAction(object sender, EventArgs e)
    {
        if (ShowSelectionError()) return;

        var selectedIndex = requestsListBox.SelectedIndex;
        var song = MainForm.MusicManager.RequestedSongs[selectedIndex];

        MainForm.MusicManager.Queue.Enqueue(song);
        
        MainForm.MusicManager.RequestedSongs.RemoveAt(selectedIndex);
        requestsListBox.Items.RemoveAt(selectedIndex);
    }

    private void RemoveAction(object sender, EventArgs e)
    {
        var selectedIndex = requestsListBox.SelectedIndex;
        
        MainForm.MusicManager.RequestedSongs.RemoveAt(selectedIndex);
        requestsListBox.Items.RemoveAt(selectedIndex);
    }

    private void ClearAction(object sender, EventArgs e)
    {
        MainForm.MusicManager.RequestedSongs.Clear();
        requestsListBox.Items.Clear();
    }
    
    #endregion

    #region Request events

    private void OnRequest(MusicManager musicManager, Song.RequestedSong song)
    {
        requestsListBox.Items.Add(song);
    }
    #endregion
    
    #region Form events
    private void SongRequestsForm_Load(object sender, EventArgs e)
    {
        MainForm.MusicManager.OnSongRequest += OnRequest;
    }
    
    private void SongRequestsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        MainForm.MusicManager.OnSongRequest -= OnRequest;
    }
    
    private void autoAcceptSwitch_CheckedChanged(object sender, EventArgs e)
    {
        addToSongGroupBox.Enabled = autoAcceptSwitch.Checked;
        AutoAcceptSongs = autoAcceptSwitch.Checked;
    }

    private void autoFrontRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        AutomationQueuePosition = MusicManager.AutomationQueuePosition.First;
    }

    private void autoEndRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        AutomationQueuePosition = MusicManager.AutomationQueuePosition.Last;
    }

    private void queueListBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected,
                e.ForeColor, Style.Colors.ListBoxSelectedBackground);

        e.DrawBackground();

        if (e.Index == -1) return;

        if (((ListBox)sender).Items[e.Index] is not Song.RequestedSong dataItem) return;

        var index = (e.Index + 1).ToString();
        var textIdent = e.Bounds.Left + 20 + index.Length * 7;

        // TODO drawIcon

        e.Graphics.DrawString(index, Style.Fonts.QueueSongPosition, Style.Brushes.QueueSongPosition, e.Bounds.Left + 1,
            e.Bounds.Top + 8);
        e.Graphics.DrawString(dataItem.Name, Style.Fonts.SongName, Style.Brushes.SongName, textIdent,
            e.Bounds.Top + 5);
        e.Graphics.DrawString(dataItem.Author, Style.Fonts.SongAuthors, Style.Brushes.SongAuthors, textIdent,
            e.Bounds.Top + 18);
        e.Graphics.DrawString(@"Requested by: " + dataItem.Requester, Style.Fonts.Requester,
            Style.Brushes.Requester, e.Bounds.Left + 200, e.Bounds.Top + 18);
    }
    #endregion

    private void button1_Click(object sender, EventArgs e)
    {
        MainForm.MusicManager.AddRequestedSong(MainForm.MusicManager.SongSources.RandomSong().CreateRequestedSong("Ivan"));
    }
}