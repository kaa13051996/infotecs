using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;

namespace RSS_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Session _session;
        private DispatcherTimer timer = new DispatcherTimer();
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        } 

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _session = new Session();
            int frequency = _session._settings.GetFrequency();            
            timer.Tick += Main_Tick;
            timer.Interval = TimeSpan.FromMinutes(frequency);
            timer.Start();
            
            Main_Tick(null, null);
        }

        private void Main_Tick(object sender, EventArgs e)
        {            
            _session.ProgressChanged += _session_ProgressChanged;
            _session.OutputData += _session_OutputData;            
            Task thread = new Task(_session.OutputChannels);
            thread.Start();
        }
        
        private void _session_OutputData(bool obj)
        {
            Action action = () =>
            {                
                progressBar.Value = 0;
                list.ItemsSource = _session.channels;                
            };
            if (!Dispatcher.CheckAccess()) Dispatcher.Invoke(action);
            else action();
        }
                
        private void _session_ProgressChanged(int progress)
        {
            Action action = () =>
            {
                progressBar.Value = progress;                           
            };
            if (!Dispatcher.CheckAccess()) Dispatcher.Invoke(action);
            else action();
        }

        private void ClickChannel(object sender, RoutedEventArgs e)
        {
            try { Process.Start(((Hyperlink)sender).NavigateUri.ToString()); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToHome();            
        }

        private void Button_Settings(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();   
            MainWindow_Loaded(sender, e);
        }         

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbDescription.DataContext = e.AddedItems;
        }       
        
    }
}
