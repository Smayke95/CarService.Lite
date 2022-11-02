using CarService.Models;
using CarService.ViewModels;
using System.Collections.Generic;

namespace CarService.Interfaces
{
    public interface IServiceService : ICrudService<Service>
    {
        IEnumerable<ServiceViewModel> GetAllByVehicle(int vehicleId);
        ServiceViewModel Insert(ServiceViewModel model);
        ServiceViewModel Update(ServiceViewModel model);
    }
}