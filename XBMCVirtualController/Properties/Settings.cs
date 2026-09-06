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
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace XBMCVirtualController.Properties
{

    /// <summary>
    /// User settings, stored as JSON under %AppData%.
    ///
    /// This replaces the old ApplicationSettingsBase/app.config settings: the
    /// System.Configuration settings provider derives its store path from
    /// Assembly.Location, which is empty in a single-file published app, so
    /// user settings would silently fail to persist.
    /// </summary>
    internal sealed class Settings
    {

        private static readonly Settings defaultInstance = Load();

        public static Settings Default
        {
            get { return defaultInstance; }
        }

        public string SkinName { get; set; } = "";

        public int WindowLocationX { get; set; } = 0;

        public int WindowLocationY { get; set; } = 0;

        public string Address { get; set; } = "localhost";

        public int Port { get; set; } = 9777;

        public bool AutoConnect { get; set; } = false;

        public bool SendSingleClick { get; set; } = false;

        [JsonIgnore]
        public Point WindowLocation
        {
            get { return new Point(WindowLocationX, WindowLocationY); }
            set { WindowLocationX = value.X; WindowLocationY = value.Y; }
        }

        private static string SettingsFile
        {
            get
            {
                string directory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "Team Blackbolt",
                    "XBMC Virtual Controller");
                return Path.Combine(directory, "settings.json");
            }
        }

        private static Settings Load()
        {
            try
            {
                string settingsFile = SettingsFile;
                if (File.Exists(settingsFile))
                {
                    Settings settings = JsonSerializer.Deserialize<Settings>(File.ReadAllText(settingsFile));
                    if (settings != null) return settings;
                }
            }
            catch
            {
                // A corrupt or unreadable settings file falls back to defaults.
            }
            return new Settings();
        }

        public void Save()
        {
            try
            {
                string settingsFile = SettingsFile;
                Directory.CreateDirectory(Path.GetDirectoryName(settingsFile));
                File.WriteAllText(settingsFile, JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch
            {
                // Settings are a convenience; never take the app down over them.
            }
        }

    }

}
