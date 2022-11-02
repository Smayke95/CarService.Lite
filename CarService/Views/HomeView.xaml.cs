using System.Windows;
using System.Windows.Controls;

namespace CarService.Views
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void btn_Vehicles_Click(object sender, RoutedEventArgs e)
            => ((MainWindow)Application.Current.MainWindow).ContentArea.Content = new VehiclesView();

        private void btn_Owners_Click(object sender, RoutedEventArgs e)
            => ((MainWindow)Application.Current.MainWindow).ContentArea.Content = new OwnersView();
    }
}