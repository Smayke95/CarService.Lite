using CarService.Interfaces;
using CarService.Services;
using CarService.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarService.Views
{
    public partial class OwnerView : UserControl
    {
        private readonly IOwnerService OwnerService;

        public OwnerView(int id)
        {
            InitializeComponent();
            OwnerService = new OwnerService();

            Load(id);
        }

        public void Load(int id)
        {
            gr_Owner.DataContext = OwnerService.Get(id);
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
            => ((MainWindow)Application.Current.MainWindow).ContentArea.Content = new OwnersView();

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            var model = (OwnerViewModel)gr_Owner.DataContext;

            if (model.Id == 0)
                OwnerService.Insert(model);
            else
                OwnerService.Update(model);

            ((MainWindow)Application.Current.MainWindow).ContentArea.Content = new OwnersView();
        }
    }
}