using CarService.Interfaces;
using CarService.Services;
using CarService.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CarService.Views
{
    public partial class VehiclesView : UserControl
    {
        private readonly IBrandService BrandService;
        private readonly IModelService ModelService;
        private readonly IVehicleService VehicleService;

        public VehiclesView()
        {
            InitializeComponent();
            BrandService = new BrandService();
            ModelService = new ModelService();
            VehicleService = new VehicleService();

            Load();
        }

        private void Load()
        {
            try
            {
                gr_Vehicles.DataContext = new VehicleViewModel();
                dg_Vehicles.ItemsSource = VehicleService.GetAll();
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
                var model = (VehicleViewModel)gr_Vehicles.DataContext;

                model.Brand = model.Brand ?? "";
                model.Model = model.Model ?? "";
                model.LicencePlate = model.LicencePlate ?? "";
                model.ChassisNumber = model.ChassisNumber ?? "";

                dg_Vehicles.ItemsSource = VehicleService
                    .GetAllWhere(x =>
                        x.Brand.Contains(model.Brand, StringComparison.OrdinalIgnoreCase) &&
                        x.Model.Contains(model.Model, StringComparison.OrdinalIgnoreCase) &&
                        x.LicencePlate.Contains(model.LicencePlate, StringComparison.OrdinalIgnoreCase) &&
                        x.ChassisNumber!.Contains(model.ChassisNumber!, StringComparison.OrdinalIgnoreCase)
                    );

                dg_Vehicles.Items.Refresh();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        private void btn_New_Click(object sender, RoutedEventArgs e)
         => ((MainWindow)Application.Current.MainWindow).ContentArea.Content = new VehicleView(0);

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var id = (int)((Button)sender).Tag;
            ((MainWindow)Application.Current.MainWindow).ContentArea.Content = new VehicleView(id);
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = (int)((Button)sender).Tag;
                VehicleService.Delete(id);
                Load();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }
    }
}