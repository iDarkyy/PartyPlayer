using System;
using System.Drawing;
using System.Windows.Forms;

namespace PartyPlayer.Controls;

public class HintedTextBox : TextBox
{
    private readonly Color DefaultColor;

    public HintedTextBox(string placeholderText)
    {
        // get default color of text
        DefaultColor = ForeColor;
        // Add event handler for when the control gets focus
        GotFocus += (_, _) =>
        {
            Text = String.Empty;
            ForeColor = DefaultColor;
        };

        // add event handling when focus is lost
        LostFocus += (_, _) =>
        {
            if (string.IsNullOrEmpty(Text) || Text == PlaceHolderText)
            {
                ForeColor = Color.Gray;
                Text = PlaceHolderText;
            }
            else
            {
                ForeColor = DefaultColor;
            }
        };


        if (string.IsNullOrEmpty(placeholderText)) return;
        // change style   
        ForeColor = Color.Gray;
        // Add text
        PlaceHolderText = placeholderText;
        Text = placeholderText;
    }

    public sealed override string Text
    {
        get => base.Text;
        set => base.Text = value;
    }

    public sealed override Color ForeColor
    {
        get => base.ForeColor;
        set => base.ForeColor = value;
    }

    public string PlaceHolderText { get; set; }
}