using CarService.Interfaces;
using CarService.Models;
using CarService.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Services
{
    public class ServiceService : CrudService<Service>, IServiceService
    {
        public IEnumerable<ServiceViewModel> GetAllByVehicle(int vehicleId)
        {
            using (var context = new CSContext())
            {
                var services = context
                    .Services!
                    .Where(x => x.VehicleId == vehicleId);

                return App.Mapper.Map<IEnumerable<ServiceViewModel>>(services);
            }
        }

        public ServiceViewModel Insert(ServiceViewModel model)
        {
            var addedService = base.Insert(App.Mapper.Map<Service>(model));
            return App.Mapper.Map<ServiceViewModel>(addedService);
        }

        public ServiceViewModel Update(ServiceViewModel model)
        {
            var updatedService = base.Update(App.Mapper.Map<Service>(model));
            return App.Mapper.Map<ServiceViewModel>(updatedService);
        }
    }
}