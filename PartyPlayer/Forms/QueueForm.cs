using System;
using System.Windows.Forms;
using PartyPlayer.Music;
using PartyPlayer.Utils;

namespace PartyPlayer.Forms;

public partial class QueueForm : Form
{
    public QueueForm(MainForm mainForm)
    {
        MainForm = mainForm;
        InitializeComponent();

        foreach (var song in MainForm.MusicManager.Queue)
        {
            queueListBox.Items.Add(song);
        }
    }

    private MainForm MainForm { get; }

    #region Draw

    private void queueListBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected,
                e.ForeColor, Style.Colors.ListBoxSelectedBackground);

        e.DrawBackground();

        if (e.Index == -1) return;

        if (((ListBox)sender).Items[e.Index] is not Song dataItem) return;

        var index = (e.Index + 1).ToString();
        var textIdent = e.Bounds.Left + 20 + index.Length * 7;

        // TODO drawIcon

        e.Graphics.DrawString(index, Style.Fonts.QueueSongPosition, Style.Brushes.QueueSongPosition, e.Bounds.Left + 1,
            e.Bounds.Top + 8);
        e.Graphics.DrawString(dataItem.Name, Style.Fonts.SongName, Style.Brushes.SongName, textIdent,
            e.Bounds.Top + 5);
        e.Graphics.DrawString(dataItem.Author, Style.Fonts.SongAuthors, Style.Brushes.SongAuthors, textIdent,
            e.Bounds.Top + 18);

        if (dataItem is Song.RequestedSong song)
            e.Graphics.DrawString(@"Requested by: " + song.Requester, Style.Fonts.Requester,
                Style.Brushes.Requester, e.Bounds.Left + 200, e.Bounds.Top + 18);
    }

    #endregion
    
    #region Actions

    private bool ShowSelectionError()
    {
        if (queueListBox.SelectedIndex != -1) return false;
        MessageBox.Show(@"No song has been selected", @"Selection error", MessageBoxButtons.OK,
            MessageBoxIcon.Error);

        return true;
    }

    private void PlayNowAction(object sender, EventArgs e)
    {
        if (ShowSelectionError()) return;

        MainForm.MusicManager.Queue.Dequeue(queueListBox.SelectedIndex);
    }

    private void PlayNextAction(object sender, EventArgs e)
    {
        if (ShowSelectionError()) return;


        MainForm.MusicManager.Queue.Move(queueListBox.SelectedIndex, 0);
    }

    private void RemoveAction(object sender, EventArgs e)
    {
        if (ShowSelectionError()) return;

        MainForm.MusicManager.Queue.RemoveAt(queueListBox.SelectedIndex);
    }

    private void MoveUpAction(object sender, EventArgs e)
    {
        if (ShowSelectionError()) return;

        var selectedIndex = queueListBox.SelectedIndex;

        if (selectedIndex == 0) return;

        MainForm.MusicManager.Queue.Move(selectedIndex, selectedIndex - 1);
    }

    private void MoveDownAction(object sender, EventArgs e)
    {
        if (ShowSelectionError()) return;

        var selectedIndex = queueListBox.SelectedIndex;

        if (selectedIndex == MainForm.MusicManager.Queue.Count - 1) return;

        MainForm.MusicManager.Queue.Move(selectedIndex, selectedIndex + 1);
    }

    public void ClearAction(object sender, EventArgs e)
    {
        if (queueListBox.Items.Count == 0) return;
        MainForm.MusicManager.Queue.GetList().Clear();
        queueListBox.Items.Clear();
    }
    
    #endregion

    #region Events

    private void QueueForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        MainForm.MusicManager.Queue.QueueItemAdded -= QueueItemAdd;
        MainForm.MusicManager.Queue.QueueItemRemoved -= QueueItemRemove;
        MainForm.MusicManager.Queue.QueueItemMoved -= QueueItemMove;
    }

    private void QueueForm_Load(object sender, EventArgs e)
    {
        MainForm.MusicManager.Queue.QueueItemAdded += QueueItemAdd;
        MainForm.MusicManager.Queue.QueueItemRemoved += QueueItemRemove;
        MainForm.MusicManager.Queue.QueueItemMoved += QueueItemMove;
    }

    private void QueueItemAdd(object src, QueueItemAddedArgs e)
    {
        var queue = (ListQueue<Song>)src;
        queueListBox.Items.Insert(e.Index, queue[e.Index]);
    }

    private void QueueItemRemove(object src, QueueItemRemovedArgs e)
    {
        queueListBox.Items.RemoveAt(e.Index);
    }

    private void QueueItemMove(object src, QueueItemMovedArgs e)
    {
        var queue = (ListQueue<Song>)src;
        queueListBox.Items.RemoveAt(e.OldIndex);
        queueListBox.Items.Insert(e.NewIndex, queue[e.NewIndex]);
    }

    #endregion
}