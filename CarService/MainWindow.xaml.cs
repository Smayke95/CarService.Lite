using CarService.Models;
using CarService.Properties;
using CarService.Views;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace CarService
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Trace.TraceInformation("Application started.");
            InitializeComponent();

            MainTitle.Content = Settings.Default.ServiceName;
            ContentArea.Content = new HomeView();

            using (var context = new CSContext())
                context.Database.EnsureCreated();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btn_Minimize_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void btn_Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                btn_MaximizeIcon.Kind = PackIconKind.WindowMaximize;
            }
            else
            {
                WindowState = WindowState.Maximized;
                btn_MaximizeIcon.Kind = PackIconKind.WindowRestore;
            }
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}