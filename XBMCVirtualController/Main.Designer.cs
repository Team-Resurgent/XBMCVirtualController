namespace XBMCVirtualController
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.timerPing = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.skinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemScale50 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemScale60 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemScale70 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemScale80 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemScale90 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemScale100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSendSingleClick = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerPing
            // 
            this.timerPing.Interval = 3000;
            this.timerPing.Tick += new System.EventHandler(this.timerPing_Tick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skinToolStripMenuItem,
            this.scaleToolStripMenuItem,
            this.toolStripMenuItemHide,
            this.toolStripMenuItemConnection,
            this.toolStripMenuItemSendSingleClick,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(219, 240);
            // 
            // skinToolStripMenuItem
            // 
            this.skinToolStripMenuItem.Name = "skinToolStripMenuItem";
            this.skinToolStripMenuItem.Size = new System.Drawing.Size(218, 32);
            this.skinToolStripMenuItem.Text = "Skin";
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemScale50,
            this.toolStripMenuItemScale60,
            this.toolStripMenuItemScale70,
            this.toolStripMenuItemScale80,
            this.toolStripMenuItemScale90,
            this.toolStripMenuItemScale100});
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(218, 32);
            this.scaleToolStripMenuItem.Text = "Scale";
            // 
            // toolStripMenuItemScale50
            // 
            this.toolStripMenuItemScale50.Name = "toolStripMenuItemScale50";
            this.toolStripMenuItemScale50.Size = new System.Drawing.Size(159, 34);
            this.toolStripMenuItemScale50.Text = "50%";
            this.toolStripMenuItemScale50.Click += new System.EventHandler(this.toolStripMenuItemScale50_Click);
            // 
            // toolStripMenuItemScale60
            // 
            this.toolStripMenuItemScale60.Name = "toolStripMenuItemScale60";
            this.toolStripMenuItemScale60.Size = new System.Drawing.Size(159, 34);
            this.toolStripMenuItemScale60.Text = "60%";
            this.toolStripMenuItemScale60.Click += new System.EventHandler(this.toolStripMenuItemScale60_Click);
            // 
            // toolStripMenuItemScale70
            // 
            this.toolStripMenuItemScale70.Name = "toolStripMenuItemScale70";
            this.toolStripMenuItemScale70.Size = new System.Drawing.Size(159, 34);
            this.toolStripMenuItemScale70.Text = "70%";
            this.toolStripMenuItemScale70.Click += new System.EventHandler(this.toolStripMenuItemScale70_Click);
            // 
            // toolStripMenuItemScale80
            // 
            this.toolStripMenuItemScale80.Name = "toolStripMenuItemScale80";
            this.toolStripMenuItemScale80.Size = new System.Drawing.Size(159, 34);
            this.toolStripMenuItemScale80.Text = "80%";
            this.toolStripMenuItemScale80.Click += new System.EventHandler(this.toolStripMenuItemScale80_Click);
            // 
            // toolStripMenuItemScale90
            // 
            this.toolStripMenuItemScale90.Name = "toolStripMenuItemScale90";
            this.toolStripMenuItemScale90.Size = new System.Drawing.Size(159, 34);
            this.toolStripMenuItemScale90.Text = "90%";
            this.toolStripMenuItemScale90.Click += new System.EventHandler(this.toolStripMenuItemScale90_Click);
            // 
            // toolStripMenuItemScale100
            // 
            this.toolStripMenuItemScale100.Checked = true;
            this.toolStripMenuItemScale100.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemScale100.Name = "toolStripMenuItemScale100";
            this.toolStripMenuItemScale100.Size = new System.Drawing.Size(159, 34);
            this.toolStripMenuItemScale100.Text = "100%";
            this.toolStripMenuItemScale100.Click += new System.EventHandler(this.toolStripMenuItemScale100_Click);
            // 
            // toolStripMenuItemHide
            // 
            this.toolStripMenuItemHide.Name = "toolStripMenuItemHide";
            this.toolStripMenuItemHide.Size = new System.Drawing.Size(218, 32);
            this.toolStripMenuItemHide.Text = "Hide";
            this.toolStripMenuItemHide.Click += new System.EventHandler(this.toolStripMenuItemHide_Click);
            // 
            // toolStripMenuItemConnection
            // 
            this.toolStripMenuItemConnection.Name = "toolStripMenuItemConnection";
            this.toolStripMenuItemConnection.Size = new System.Drawing.Size(218, 32);
            this.toolStripMenuItemConnection.Text = "Connection";
            this.toolStripMenuItemConnection.Click += new System.EventHandler(this.toolStripMenuItemConnection_Click);
            // 
            // toolStripMenuItemSendSingleClick
            // 
            this.toolStripMenuItemSendSingleClick.Name = "toolStripMenuItemSendSingleClick";
            this.toolStripMenuItemSendSingleClick.Size = new System.Drawing.Size(218, 32);
            this.toolStripMenuItemSendSingleClick.Text = "Send Single Click";
            this.toolStripMenuItemSendSingleClick.Click += new System.EventHandler(this.toolStripMenuItemSendSingleClick_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(218, 32);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(218, 32);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // toolTip
            // 
            this.toolTip.UseAnimation = false;
            this.toolTip.UseFading = false;
            this.toolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip_Popup);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(164, 169);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "XBMC Virual Remote";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseLeave += new System.EventHandler(this.Main_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerPing;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScale50;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScale60;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScale70;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScale80;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScale90;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem skinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScale100;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHide;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConnection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSendSingleClick;

    }
}