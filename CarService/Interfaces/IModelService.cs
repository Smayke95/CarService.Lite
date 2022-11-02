using CarService.Models;
using System.Collections.Generic;

namespace CarService.Interfaces
{
    public interface IModelService : ICrudService<Model>
    {
        IEnumerable<Model> GetAllByBrand(int brandId);
    }
}