using CarService.Models;
using CarService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarService.Interfaces
{
    public interface IVehicleService : ICrudService<Vehicle>
    {
        new VehicleViewModel Get(int id);
        new IEnumerable<VehicleViewModel> GetAll();
        IEnumerable<VehicleViewModel> GetAllWhere(Func<Vehicle, bool> where);
        VehicleViewModel Insert(VehicleViewModel model);
        VehicleViewModel Update(VehicleViewModel model);
    }
}