using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin.Controls;
using PartyPlayer.Music;

namespace PartyPlayer.Forms;

public partial class SettingsForm : Form
{
    public MainForm MainForm { get; }
    private Dictionary<Control, FieldInfo> SettingControls = new();

    public SettingsForm(MainForm mainForm)
    {
        MainForm = mainForm;
        InitializeComponent();
        
        GenerateSettings();
    }

    private void GenerateSettings()
    {
        var cm = MainForm.ConfigurationManager;
        var fields = MainForm.ConfigurationManager.Configuration.GetType().GetFields(BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static);

        var matcher = new Regex("<([a-zA-Z_]+)>");
        
        foreach (var field in fields)
        {
            var type = field.FieldType;
            var name = ParseName(matcher.Match(field.Name).Groups[1].Value);

            if (type == typeof(string))
            {
                var textBox = new MaterialTextBox()
                {
                    Hint = name,
                    Dock = DockStyle.Top,
                    Text = (string) field.GetValue(cm.Configuration)
                };

                settingPanel.Controls.Add(textBox);
                SettingControls.Add(textBox, field);
                
            } else if (type == typeof(int))
            {
                var textBox = new MaterialTextBox()
                {
                    Hint = name,
                    Dock = DockStyle.Top,
                    Text = field.GetValue(cm.Configuration).ToString()
                };

                settingPanel.Controls.Add(textBox);
                SettingControls.Add(textBox, field);
            } else if (type == typeof(bool))
            {
                var textBox = new MaterialSwitch()
                {
                    Text = name,
                    Dock = DockStyle.Top,
                    Checked = (bool) field.GetValue(cm.Configuration)
                };
                
                settingPanel.Controls.Add(textBox);
                SettingControls.Add(textBox, field);
            }
        }

        var saveButton = new MaterialButton()
        {
            Text = @"Save settings",
            Dock = DockStyle.Bottom
        };

        saveButton.Click += (_, _) =>
        {
            foreach (var pair in SettingControls)
            {
                if (pair.Key is MaterialTextBox textBox)
                {
                    if (pair.Value.FieldType == typeof(int))
                    {
                        int value;
                        var success = int.TryParse(textBox.Text, out value);

                        if (!success)
                        {
                            MessageBox.Show(@$"Invalid value for {textBox.Hint}. Must be an int", @"Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                        pair.Value.SetValue(cm.Configuration, value);
                    }
                    else
                    {
                        pair.Value.SetValue(cm.Configuration, textBox.Text);
                    }
                } else if (pair.Key is MaterialSwitch matSwitch)
                {
                    pair.Value.SetValue(cm.Configuration, matSwitch.Checked);
                }
            }

            MainForm.ConfigurationManager.Save();
            MessageBox.Show(@"Saved configuration", @"Successful",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        };
        
        settingPanel.Controls.Add(saveButton);
    }

    private static string ParseName(string name)
    {
        var builder = new StringBuilder();

        for (var i = 0; i < name.Length; i++)
        {
            var c = name[i];

            if (i != 0 && char.IsUpper(c))
            {
                builder.Append(' ');
                builder.Append(char.ToLower(c));
            }
            else
            {
                builder.Append(c);
            }
        }

        return builder.ToString();
    }
}