using CarService.Interfaces;
using CarService.Services;
using CarService.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CarService.Views
{
    public partial class OwnersView : UserControl
    {
        private readonly IOwnerService OwnerService;

        public OwnersView()
        {
            InitializeComponent();
            OwnerService = new OwnerService();

            Load();
        }

        private void Load()
        {
            try
            {
                dg_Owners.ItemsSource = OwnerService.GetAll();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
            => ((MainWindow)Application.Current.MainWindow).ContentArea.Content = new HomeView();

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var model = (OwnerViewModel)gr_Owners.DataContext;

                dg_Owners.ItemsSource = OwnerService
                    .GetAll()
                    .Where(x =>
                        x.FirstName.IndexOf(model.FirstName, StringComparison.OrdinalIgnoreCase) >= 0 &&
                        x.LastName.IndexOf(model.LastName, StringComparison.OrdinalIgnoreCase) >= 0
                    );

                dg_Owners.Items.Refresh();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ContentArea.Content = new OwnerView(0);
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var id = (int)((Button)sender).Tag;
            ((MainWindow)Application.Current.MainWindow).ContentArea.Content = new OwnerView(id);
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = (int)((Button)sender).Tag;
                OwnerService.Delete(id);
                Load();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }
    }
}