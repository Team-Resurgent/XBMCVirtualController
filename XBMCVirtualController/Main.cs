//
//  Copyright (C) 2009 Team Blackbolt
//  http://www.teamblackbolt.co.uk/
//
//  This Program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2, or (at your option)
//  any later version.
//
//  This Program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using XBMC;
using System.Runtime.InteropServices;

namespace XBMCVirtualController
{

    public partial class Main : PerPixelAlphaForm
    {

        private string skinName;
        private bool isDragging;
        private Point startDragLocation;
        private EventClient eventClient = new EventClient();
        private SkinEngine skinEngine;
        private bool errorOccured = false;
        private string lastControl = null;

        public Main()
        {

            InitializeComponent();

        }
        
        private void Main_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SkinName == "")
            {
                string[] directories = Directory.GetDirectories(Helper.SkinPath);
                if (directories.Length < 1)
                {
                    MessageBox.Show("Skin folder appears empty.");
                    errorOccured = true;
                }
                else
                {
                    Properties.Settings.Default.SkinName = Path.GetFileName(directories[0]);
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                if (!File.Exists(Helper.SkinPath + Properties.Settings.Default.SkinName + @"\Skin.xml"))
                {
                    string[] directories = Directory.GetDirectories(Helper.SkinPath);
                    if (directories.Length < 1)
                    {
                        MessageBox.Show("Skin folder appears empty.");
                        errorOccured = true;
                    }
                    else
                    {
                        MessageBox.Show("Skin '" + Properties.Settings.Default.SkinName + "' does not appear to exist, reverting to '" + Path.GetFileName(directories[0]) + "'.");
                        Properties.Settings.Default.SkinName = Path.GetFileName(directories[0]);
                        Properties.Settings.Default.Save();
                    }
                }
            }

            Splash splash = new Splash();
            splash.ShowDialog();

            if (!errorOccured)
            {
                skinEngine = new SkinEngine(this);
                skinName = Properties.Settings.Default.SkinName;
                this.Location = Properties.Settings.Default.WindowLocation;
                toolStripMenuItemSendSingleClick.Checked = Properties.Settings.Default.SendSingleClick;
                string errorMEssage = skinEngine.LoadSkin(skinName);
                if (errorMEssage == "")
                    UpdateContextMenu();
                else
                {
                    MessageBox.Show(errorMEssage);
                    errorOccured = true;
                }
            }

        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (!errorOccured)
            {
                if (Properties.Settings.Default.AutoConnect)
                {
                    eventClient.Connect(Properties.Settings.Default.Address, Properties.Settings.Default.Port);
                    eventClient.SendHelo("Team Blackbolt - XBMC Virtual Remote", IconType.ICON_PNG, Helper.AppPath + "remotecontrol.png");
                    timerPing.Enabled = true;
                }
                else
                {
                    Connection connect = new Connection();
                    if (connect.ShowDialog(this) == DialogResult.OK)
                    {
                        eventClient.Connect(connect.Address, connect.Port);
                        eventClient.SendHelo("Team Blackbolt - XBMC Virtual Remote", IconType.ICON_PNG, Helper.AppPath + "remotecontrol.png");
                        timerPing.Enabled = true;
                    }
                    else
                        this.Close();
                }
            }
            else
                this.Close();
        }


        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            eventClient.SendBye();
            eventClient.Disconnect();
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(this.Left + e.X, this.Top + e.Y);
            }
            else if (e.Button == MouseButtons.Left)
            {

                bool buttonPressed = false;
                foreach (skinControl skincontrol in skinEngine.Skin.controls)
                {
                    if (skincontrol.type.ToLower() == "button")
                    {

                        int xpos = (int)(int.Parse(skincontrol.xpos) * skinEngine.Scale);
                        int ypos = (int)(int.Parse(skincontrol.ypos) * skinEngine.Scale);
                        int width = (int)(int.Parse(skincontrol.width) * skinEngine.Scale);
                        int height = (int)(int.Parse(skincontrol.height) * skinEngine.Scale);

                        if (e.X >= xpos && e.X <= xpos + width)
                        {
                            if (e.Y >= ypos && e.Y <= ypos + height)
                            {
                                string button = skincontrol.id.ToLower();
                                string buttoncommand;

                                if (!skinEngine.AltMode || skincontrol.altbuttoncommand == null)
                                    buttoncommand = skincontrol.buttoncommand;
                                else
                                    buttoncommand = skincontrol.altbuttoncommand;

                                if (button != "closeprogram")
                                {
                                    if (buttoncommand != null)
                                    {
                                        
                                        string device = "R1";
                                        string command = "";
                                        string[] buttonParams = buttoncommand.Split(',');

                                        if (buttonParams.Length == 1)
                                            command = buttonParams[0].Trim().ToLower();
                                        else
                                        {
                                            device = buttonParams[0].Trim().ToUpper();
                                            command = buttonParams[1].Trim().ToLower();
                                        }

                                        if (command != "")
                                        {
                                            ButtonFlagsType buttonFlagType = ButtonFlagsType.BTN_DOWN;
                                            if (toolStripMenuItemSendSingleClick.Checked) buttonFlagType = buttonFlagType | ButtonFlagsType.BTN_NO_REPEAT;
                                            eventClient.SendButton(command, device, buttonFlagType);
                                        }

                                    }
                                    buttonPressed = true;
                                    this.SetBitmap(skinEngine.RenderSkin(skinEngine.Skin, button, false, true));
                                    break;
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                        }

                    }
                }

                if (!buttonPressed)
                {
                    isDragging = true;
                    startDragLocation = e.Location;
                }

            }
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            if (!toolStripMenuItemSendSingleClick.Checked) eventClient.SendButton();
            this.SetBitmap(skinEngine.RenderSkin(skinEngine.Skin));
        }

        private void Main_MouseLeave(object sender, EventArgs e)
        {
            this.SetBitmap(skinEngine.RenderSkin(skinEngine.Skin));
            lastControl = null;
            toolTip.Hide(this);
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                SnapToDesktopBorder(new Point(this.Location.X + (e.X - startDragLocation.X), this.Location.Y + (e.Y - startDragLocation.Y)));
            }
            else
            {

                int xposTooltip = (int)(int.Parse(skinEngine.Skin.layout.width) * skinEngine.Scale);
                int yposTooltip = (int)(int.Parse(skinEngine.Skin.layout.height) * skinEngine.Scale);
                string control = "window";
                string button = "";

                for (int i = skinEngine.Skin.controls.Length - 1; i >= 0; i--)
                {

                    skinControl skincontrol = skinEngine.Skin.controls[i];
                    int xpos = (int)(int.Parse(skincontrol.xpos) * skinEngine.Scale);
                    int ypos = (int)(int.Parse(skincontrol.ypos) * skinEngine.Scale);
                    int width = (int)(int.Parse(skincontrol.width) * skinEngine.Scale);
                    int height = (int)(int.Parse(skincontrol.height) * skinEngine.Scale);

                    if (e.X >= xpos && e.X <= xpos + width)
                    {
                        if (e.Y >= ypos && e.Y <= ypos + height)
                        {

                            xposTooltip = xpos + width;
                            yposTooltip = ypos + height;

                            if (skincontrol.type.ToLower() == "image")
                            {
                                control = "image: " + skincontrol.id.ToLower();
                                break;
                            }
                            else if (skincontrol.type.ToLower() == "button")
                            {
                                button = skincontrol.id.ToLower();
                                control = "button: " + skincontrol.id.ToLower();
                                control += "\nbuttoncommand: " + skincontrol.buttoncommand.ToLower();
                                break;
                            }

                        }
                    }

                }

                this.SetBitmap(skinEngine.RenderSkin(skinEngine.Skin, button, true, false));

                if (skinEngine.Skin.debug.ToLower() == "true"  && control != lastControl)
                    toolTip.Show(control, this, xposTooltip, yposTooltip, 2000);

                lastControl = control;

            }

        }

        private void timerPing_Tick(object sender, EventArgs e)
        {
            eventClient.SendPing();
        }

        public void SnapToDesktopBorder(Point position)
        {

            const int snapOffset = 30;

            Screen screen = Screen.FromPoint(position);

            // Left border
            if (position.X >= screen.WorkingArea.X - snapOffset && position.X <= screen.WorkingArea.X + snapOffset)
                position.X = screen.WorkingArea.X;

            //Top border
            if (position.Y >= screen.WorkingArea.Y - snapOffset && position.Y <= screen.WorkingArea.Y + snapOffset)
                position.Y = screen.WorkingArea.Y;

            // Right border
            if (position.X + this.Width <= screen.WorkingArea.Right + snapOffset && position.X + this.Width >= screen.WorkingArea.Right - snapOffset)
                position.X = screen.WorkingArea.Right - this.Width;

            // Bottom border
            if (position.Y + this.Height <= screen.WorkingArea.Bottom + snapOffset && position.Y + this.Height >= screen.WorkingArea.Bottom - snapOffset)
                position.Y = screen.WorkingArea.Bottom - this.Height;

            this.Location = position;

        }

        private void SaveSettings()
        {
            if (!errorOccured)
            {
                Properties.Settings.Default.SkinName = skinName;
                Properties.Settings.Default.WindowLocation = this.Location;
                Properties.Settings.Default.SendSingleClick = toolStripMenuItemSendSingleClick.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void UpdateContextMenu()
        {

            toolStripMenuItemScale50.Checked = (skinEngine.Scale == 0.5f);
            toolStripMenuItemScale60.Checked = (skinEngine.Scale == 0.6f);
            toolStripMenuItemScale70.Checked = (skinEngine.Scale == 0.7f);
            toolStripMenuItemScale80.Checked = (skinEngine.Scale == 0.8f);
            toolStripMenuItemScale90.Checked = (skinEngine.Scale == 0.9f);
            toolStripMenuItemScale100.Checked = (skinEngine.Scale == 1.0f);

            skinToolStripMenuItem.DropDownItems.Clear();
            try
            {
                string[] directories = Directory.GetDirectories(Helper.SkinPath);
                foreach (string directory in directories)
                {
                    if (File.Exists(directory + @"\skin.xml"))
                    {
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(Path.GetFileName(directory));
                        if (skinName.ToLower() == toolStripMenuItem.Text.ToLower()) toolStripMenuItem.Checked = true;
                        skinToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                        toolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemSkinSelect_Click);
                    }
                }
            }
            catch
            {
            }

            if (this.Visible)
                toolStripMenuItemHide.Text = "Hide";
            else
                toolStripMenuItemHide.Text = "Show";

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItemScale50_Click(object sender, EventArgs e)
        {
            skinEngine.Scale = 0.5f;
            UpdateContextMenu();
        }

        private void toolStripMenuItemScale60_Click(object sender, EventArgs e)
        {
            skinEngine.Scale = 0.6f;
            UpdateContextMenu();
        }

        private void toolStripMenuItemScale70_Click(object sender, EventArgs e)
        {
            skinEngine.Scale = 0.7f;
            UpdateContextMenu();
        }

        private void toolStripMenuItemScale80_Click(object sender, EventArgs e)
        {
            skinEngine.Scale = 0.8f;
            UpdateContextMenu();
        }

        private void toolStripMenuItemScale90_Click(object sender, EventArgs e)
        {
            skinEngine.Scale = 0.9f;
            UpdateContextMenu();
        }

        private void toolStripMenuItemScale100_Click(object sender, EventArgs e)
        {
            skinEngine.Scale = 1.0f;
            UpdateContextMenu();
        }

        private void toolStripMenuItemSkinSelect_Click(object sender, EventArgs e)
        {
            skinName = ((ToolStripMenuItem)sender).Text;
            string errorMEssage = skinEngine.LoadSkin(skinName);
            if (errorMEssage == "")
                UpdateContextMenu();
            else
            {
                MessageBox.Show(errorMEssage);
                errorOccured = true;
                this.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.skinname = skinEngine.Skin.credits.skinname;
            about.info = skinEngine.Skin.credits.info;
            about.ShowDialog();
        }

        private void toolStripMenuItemHide_Click(object sender, EventArgs e)
        {
            if (this.Visible)
                this.Hide();
            else
                this.Show();
            UpdateContextMenu();
        }

        private void toolTip_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolStripMenuItemConnection_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            if (connect.ShowDialog(this) == DialogResult.OK)
            {
                eventClient.Disconnect();
                eventClient.Connect(connect.Address, connect.Port);
                eventClient.SendHelo("Team Blackbolt - XBMC Virtual Remote", IconType.ICON_PNG, Helper.AppPath + "remotecontrol.png");
            }
        }

        private void toolStripMenuItemSendSingleClick_Click(object sender, EventArgs e)
        {
            toolStripMenuItemSendSingleClick.Checked = !toolStripMenuItemSendSingleClick.Checked;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    skinEngine.AltMode = !skinEngine.AltMode;
        //    this.SetBitmap(skinEngine.RenderSkin(skinEngine.Skin));
        //}

    }

}
