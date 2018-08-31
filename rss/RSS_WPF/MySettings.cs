using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace RSS_WPF
{
    class Settings
    {
        public static string PathFileSettings { get; } = @"../../../settings.xml";
        public static XDocument Doc
        {
            get
            {
                XDocument doc = null;
                try
                {
                    doc = XDocument.Load(PathFileSettings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(0);
                }
                return doc;
            }
        }
        public string NameSetting { get; set; }
        public string ValueSetting { get; set; }
        
        public Settings(string NameSetting, string ValueSetting)
        {
            this.NameSetting = NameSetting;
            this.ValueSetting = ValueSetting;
        }       
        public Settings() { }
        
        public List<Settings> GetSettings()
        {
            XDocument doc = Doc;
            List<Settings> settings = new List<Settings>();
            try
            {
                foreach (XElement element in doc.Element("settings").Element("parameters").Elements("parameter").ToList())
                {
                    settings.Add(new Settings(element.FirstAttribute.Value, element.Value));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return settings;
        }
        public List<Channel> GetChannelList()
        {
            List<Channel> channels = new List<Channel>();
            try
            {
                foreach (XElement element in Doc.Element("settings").Element("channels").Elements("channel").ToList())
                {
                    channels.Add(new Channel(element.FirstAttribute.Value, element.Value));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return channels;
        }
        public int GetFrequency()
        {            
            int result = Convert.ToInt32(GetSettings()[0].ValueSetting);
            if (result < 1)
            {
                MessageBox.Show("Слишком маленькая частота обновлений!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                SettingsWindow window = new SettingsWindow();
                window.ShowDialog();
            }
            return (result);
        }

        public static XElement SaveSettings(DataGrid gridChannels, DataGrid gridSettings)
        {
            XElement settings = new XElement("settings");

            //Запись каналов.
            var channelsGrid = gridChannels.Items.SourceCollection;
            XElement channels = new XElement("channels");
            foreach (Channel str in channelsGrid)
            {
                XElement channel = new XElement("channel",
                            new XAttribute("name", str.NameChannel),
                            new XElement("link", str.LinkRSS));
                channels.Add(channel);
            }

            //Запись настроек.
            var settingsGrid = gridSettings.Items.SourceCollection;
            XElement parameters = new XElement("parameters");
            foreach (Settings str in settingsGrid)
            {
                XElement parameter = new XElement("parameter",
                            new XAttribute("name", str.NameSetting),
                            new XElement("value", str.ValueSetting));
                parameters.Add(parameter);
            }
            settings.Add(parameters);
            settings.Add(channels);

            return settings;
        }
    }
}
