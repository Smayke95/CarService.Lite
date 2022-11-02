using CarService.Interfaces;
using CarService.Models;
using CarService.ViewModels;
using System.Collections.Generic;

namespace CarService.Services
{
    public class OwnerService : CrudService<Owner>, IOwnerService
    {
        public new OwnerViewModel Get(int id)
        {
            var owner = base.Get(id);
            return App.Mapper!.Map<OwnerViewModel>(owner);
        }

        public new IEnumerable<OwnerViewModel> GetAll()
        {
            var owners = base.GetAll();
            return App.Mapper!.Map<IEnumerable<OwnerViewModel>>(owners);
        }

        public OwnerViewModel Insert(OwnerViewModel model)
        {
            var addedOwner = base.Insert(App.Mapper!.Map<Owner>(model));
            return App.Mapper!.Map<OwnerViewModel>(addedOwner);
        }

        public OwnerViewModel Update(OwnerViewModel model)
        {
            var updatedOwner = base.Update(App.Mapper!.Map<Owner>(model));
            return App.Mapper!.Map<OwnerViewModel>(updatedOwner);
        }
    }
}