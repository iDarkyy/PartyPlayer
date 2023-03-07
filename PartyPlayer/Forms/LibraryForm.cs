using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PartyPlayer.Controls;
using PartyPlayer.Music;

namespace PartyPlayer.Forms;

public partial class LibraryForm : Form
{
    private readonly HintedTextBox _searchTextBox;

    public LibraryForm(MainForm mainForm)
    {
        MainForm = mainForm;
        InitializeComponent();

        // creating search bar
        _searchTextBox = new HintedTextBox("Search...")
        {
            Size = new Size(540, 20),
            Location = new Point(12, 60),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.FromArgb(65, 65, 65),
            ForeColor = Color.FromArgb(120, 120, 120)
        };

        _searchTextBox.TextChanged += searchTextBox_TextChanged;

        Controls.Add(_searchTextBox);
    }

    private MainForm MainForm { get; }

    #region Events

    private void LibraryForm_Load(object sender, EventArgs e)
    {
        // adding dirs
        foreach (var dir in MainForm.ConfigurationManager.Configuration.SourceFolders)
            directoriesListBox.Items.Add(dir);

        // adding songs
        UpdateSongs(false);
    }

    private void UnfocusHandler(object sender, EventArgs e)
    {
        //((ListBox)sender).ClearSelected();
    }

    private void searchTextBox_TextChanged(object sender, EventArgs e)
    {
        var searchQuery = string.IsNullOrEmpty(_searchTextBox.Text) || _searchTextBox.Text == _searchTextBox.PlaceHolderText
            ? string.Empty
            : _searchTextBox.Text.ToLower();

        if (string.IsNullOrEmpty(searchQuery))
        {
            UpdateSongs(false);
        }
        else
        {
            songsListBox.BeginUpdate();
            songsListBox.Items.Clear();

            foreach (var song in MainForm.MusicManager.SongSources.Songs
                         .Where(song => song.Name.ToLower().Contains(searchQuery)))
                songsListBox.Items.Add(song);

            songsListBox.EndUpdate();
        }
    }

    #endregion

    #region Directory management

    private void AddDirectoryAction(object sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog();

        var result = dialog.ShowDialog();
        if (result != DialogResult.OK) return;

        // checking if the path already exists in 
        if (MainForm.ConfigurationManager.Configuration.SourceFolders.Contains(dialog.SelectedPath))
        {
            MessageBox.Show(@"This directory is already added", @"Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // adding the dir
        MainForm.ConfigurationManager.Configuration.SourceFolders.Add(dialog.SelectedPath);
        MainForm.ConfigurationManager.Save();

        directoriesListBox.Items.Add(dialog.SelectedPath);
    }

    private void RemoveDirectoryAction(object sender, EventArgs e)
    {
        if (directoriesListBox.SelectedIndex == -1)
        {
            MessageBox.Show(@"No directory has been selected", @"Selection error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        var result = MessageBox.Show(@"Are you sure you wish to remove this folder?", @"Confirmation",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (result != DialogResult.Yes) return;

        // removing the dirs
        MainForm.ConfigurationManager.Configuration.SourceFolders.Remove((string)directoriesListBox.SelectedItem);
        MainForm.ConfigurationManager.Save();

        directoriesListBox.Items.RemoveAt(directoriesListBox.SelectedIndex);
    }

    #endregion

    #region Songs

    private void UpdateSongs(bool refresh)
    {
        if (refresh) MainForm.MusicManager.SongSources.Reload();

        songsListBox.BeginUpdate();
        songsListBox.Items.Clear();

        foreach (var song in MainForm.MusicManager.SongSources.Songs) songsListBox.Items.Add(song);

        songsListBox.EndUpdate();
    }

    private bool ShowSelectionError()
    {
        if (songsListBox.SelectedIndex != -1) return false;
        MessageBox.Show(@"No song has been selected", @"Selection error", MessageBoxButtons.OK,
            MessageBoxIcon.Error);

        return true;

    }

    private void PlayNowAction(object sender, EventArgs e)
    {
        if (ShowSelectionError()) return;
        MainForm.MusicManager.Play((Song)songsListBox.SelectedItem);
    }

    private void PlayNextAction(object sender, EventArgs e)
    {
        if (ShowSelectionError()) return;
        MainForm.MusicManager.Queue.EnqueueNext((Song)songsListBox.SelectedItem);
    }

    private void EnqueueAction(object sender, EventArgs e)
    {
        if (ShowSelectionError()) return;
        MainForm.MusicManager.Queue.Enqueue((Song)songsListBox.SelectedItem);
    }

    private void RefreshSongsAction(object sender, EventArgs e)
    {
        UpdateSongs(true);
        MessageBox.Show(@$"Found {MainForm.MusicManager.SongSources.Songs.Count} songs", @"Songs reloaded",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void songsListBox_DoubleClick(object sender, EventArgs e)
    {
        if (songsListBox.SelectedIndex == -1) return;
        MainForm.MusicManager.Play((Song) songsListBox.SelectedItem);
    }
    
    #endregion

    #region ListBox Drawing

    private void songsListBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected,
                e.ForeColor, Style.Colors.ListBoxSelectedBackground);

        e.DrawBackground();

        if (e.Index == -1) return;

        if (((ListBox)sender).Items[e.Index] is not Song dataItem) return;

        // TODO DrawIcon
        //e.Graphics.DrawImage(imageList1.Images[0], e.Bounds.Left, e.Bounds.Left + e.Bounds.Top, 40, 40);

        var textIdent = e.Bounds.Left + 5; // +50 if image is painted

        e.Graphics.DrawString(dataItem.Name, Style.Fonts.SongName, Style.Brushes.SongName, textIdent,
            e.Bounds.Top + 5);
        e.Graphics.DrawString(dataItem.Author, Style.Fonts.SongAuthors, Style.Brushes.SongAuthors, textIdent,
            e.Bounds.Top + 18);
    }

    private void directoriesListBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected,
                e.ForeColor, Style.Colors.ListBoxSelectedBackground);

        e.DrawBackground();

        if (e.Index == -1) return;

        if (((ListBox)sender).Items[e.Index] is not string dataItem) return;

        var textIdent = e.Bounds.Left + 5;

        e.Graphics.DrawString(dataItem, Style.Fonts.DirectoryPath, Style.Brushes.Directory, textIdent,
            e.Bounds.Top + 2);
    }

    #endregion
}