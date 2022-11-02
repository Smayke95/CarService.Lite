using CarService.Interfaces;
using CarService.Models;
using CarService.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Services
{
    public class VehicleService : CrudService<Vehicle>, IVehicleService
    {
        public new VehicleViewModel Get(int id)
        {
            using (var context = new CSContext())
            {
                var isNew = id == 0;

                if (!isNew)
                {
                    var vehicle = context
                        .Vehicles!
                        .Include(x => x.Owner)
                        .FirstOrDefault(x => x.Id == id);

                    return App.Mapper!.Map<VehicleViewModel>(vehicle) ?? new VehicleViewModel();
                }

                return new VehicleViewModel();
            }
        }

        public new IEnumerable<VehicleViewModel> GetAll()
        {
            using (var context = new CSContext())
            {
                var vehicles = context
                    .Vehicles!
                    .Include(x => x.Owner)
                    .ToList();

                return App.Mapper!.Map<IEnumerable<VehicleViewModel>>(vehicles);
            }
        }

        public IEnumerable<VehicleViewModel> GetAllWhere(Func<Vehicle, bool> where)
        {
            using (var context = new CSContext())
            {
                var vehicles = context
                    .Vehicles!
                    .Include(x => x.Owner)
                    .Where(where)
                    .ToList();

                return App.Mapper!.Map<IEnumerable<VehicleViewModel>>(vehicles);
            }
        }

        public VehicleViewModel Insert(VehicleViewModel model)
        {
            var addedVehicle = base.Insert(App.Mapper!.Map<Vehicle>(model));
            return App.Mapper!.Map<VehicleViewModel>(addedVehicle);
        }

        public VehicleViewModel Update(VehicleViewModel model)
        {
            var updatedVehicle = base.Update(App.Mapper!.Map<Vehicle>(model));
            return App.Mapper!.Map<VehicleViewModel>(updatedVehicle);
        }
    }
}