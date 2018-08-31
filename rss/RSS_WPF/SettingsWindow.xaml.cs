using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Xml.Linq;

namespace RSS_WPF
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private Settings _settings;

        public SettingsWindow()
        {
            InitializeComponent();
            Loaded += SettingsWindow_Loaded;
        }

        private void SettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _settings = new Settings();
            gridChannels.ItemsSource = _settings.GetChannelList();
            gridSettings.ItemsSource = _settings.GetSettings();
        }

        private void ButtonSaveSettings(object sender, RoutedEventArgs e)
        {
            bool checkEmpty = CheckEmpty();
            bool checkInvalidFrequencies = false;
            if (!checkEmpty)
            {
                checkInvalidFrequencies = CheckFrequencies();
            }            
            if (checkEmpty || checkInvalidFrequencies)
            {                
                MessageBox.Show("Все поля должны быть заполнены и частота обновлений должна быть больше 0!", "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                XDocument xdoc = new XDocument();
                xdoc.Add(Settings.SaveSettings(gridChannels, gridSettings));
                try
                {
                    xdoc.Save(Settings.PathFileSettings);
                    MessageBox.Show("Файл настроек сохранен.", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка при сохранении!", MessageBoxButton.OK, MessageBoxImage.Error); }
            }            
        }        

        private bool CheckEmpty()
        {
            bool checkEmpty = false;
            
            foreach (Channel row in gridChannels.Items.SourceCollection)
            {
                if (String.IsNullOrWhiteSpace(row.NameChannel) || String.IsNullOrWhiteSpace(row.LinkRSS))
                { checkEmpty = true; break; }
            }

            foreach (Settings row in gridSettings.Items.SourceCollection)
            {
                if (String.IsNullOrWhiteSpace(row.ValueSetting))
                { checkEmpty = true; break; }
            }

            return checkEmpty;            
        }        
        private bool CheckFrequencies()
        {
            bool checkInvalid = true;
            foreach (Settings value in gridSettings.Items.SourceCollection)
            {
                if (IsDigitsOnly(value.ValueSetting) && Convert.ToInt32(value.ValueSetting) > 0) checkInvalid = false;
            }         

            return checkInvalid;
        }
        private bool IsDigitsOnly(string str)
        {
            {
                foreach (char c in str)
                {
                    if (c < '0' || c > '9')
                        return false;
                }
                return true;
            }
        }
    }
}
