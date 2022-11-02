using CarService.Models;
using CarService.ViewModels;
using System.Collections.Generic;

namespace CarService.Interfaces
{
    public interface IOwnerService : ICrudService<Owner>
    {
        new OwnerViewModel Get(int id);
        new IEnumerable<OwnerViewModel> GetAll();
        OwnerViewModel Insert(OwnerViewModel model);
        OwnerViewModel Update(OwnerViewModel model);
    }
}