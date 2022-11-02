using CarService.Interfaces;
using CarService.Models;
using CarService.Services;
using CarService.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CarService.Views
{
    public partial class VehicleView : UserControl
    {
        private readonly IBrandService BrandService;
        private readonly IModelService ModelService;
        private readonly IOwnerService OwnerService;
        private readonly IServiceService ServiceService;
        private readonly IVehicleService VehicleService;

        private List<Model> Models { get; set; } = new List<Model>();

        public VehicleView(int id = 0)
        {
            InitializeComponent();
            BrandService = new BrandService();
            ModelService = new ModelService();
            OwnerService = new OwnerService();
            ServiceService = new ServiceService();
            VehicleService = new VehicleService();

            Load(id);
        }

        private void Load(int id)
        {
            try
            {
                cb_Brand.ItemsSource = BrandService.GetAll();
                Models = ModelService.GetAll().ToList();
                cb_Owner.ItemsSource = OwnerService.GetAll();
                gr_Vehicle.DataContext = VehicleService.Get(id);

                var test = ServiceService.GetAllByVehicle(id);
                dg_Services.ItemsSource = ServiceService.GetAllByVehicle(id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
            => ((MainWindow)Application.Current.MainWindow).ContentArea.Content = new VehiclesView();

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var model = (VehicleViewModel)gr_Vehicle.DataContext;

                if (model.Id == 0)
                    VehicleService.Insert(model);
                else
                    VehicleService.Update(model);

                foreach (var service in (IEnumerable<ServiceViewModel>)dg_Services.ItemsSource)
                {
                    if (service.Id == 0)
                    {
                        service.VehicleId = model.Id;
                        ServiceService.Insert(service);
                    }
                    else
                    {
                        ServiceService.Update(service);
                    }
                }

                ((MainWindow)Application.Current.MainWindow).ContentArea.Content = new VehiclesView();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        private void btn_DeleteService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var id = (int)((Button)sender).Tag;
                ServiceService.Delete(id);

                var model = (VehicleViewModel)gr_Vehicle.DataContext;
                Load(model.Id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        private void btn_Brand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var brand = (Brand)cb_Brand.SelectedValue;

            cb_Model.ItemsSource = Models
                .Where(x => x.BrandId == brand.Id)
                .OrderBy(x => x.Name);

            cb_Model.IsEnabled = true;
        }

        private void dp_Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dg_Services.BeginEdit();
        }
    }
}