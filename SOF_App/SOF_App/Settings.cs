using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOF_App
{
   
  public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string ID
        {
            get
            {
                return AppSettings.GetValueOrDefault("ID", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("ID", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("password", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("password", value);
            }
        }

        public static string Type
        {
            get
            {
                return AppSettings.GetValueOrDefault("type", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("type", value);
            }
        }

    }
    }

