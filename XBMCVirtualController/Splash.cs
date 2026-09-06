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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XBMCVirtualController
{

    public partial class Splash : PerPixelAlphaForm
    {

        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            this.Width = XBMCVirtualController.Properties.Resources.splash.Width;
            this.Height = XBMCVirtualController.Properties.Resources.splash.Height;
            SetBitmap(XBMCVirtualController.Properties.Resources.splash);

            // Shown modally at startup, so it can hide behind other windows for the
            // two seconds it lives - during which the app looks like it did nothing.
            TopMost = true;
            BringToFront();
            Activate();
        }

        private void Splash_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Splash_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Close();
        }

    }

}
