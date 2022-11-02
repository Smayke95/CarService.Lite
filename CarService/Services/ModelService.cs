using CarService.Interfaces;
using CarService.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Services
{
    public class ModelService : CrudService<Model>, IModelService
    {
        public IEnumerable<Model> GetAllByBrand(int brandId)
        {
            using (var context = new CSContext())
            {
                return context
                    .Models!
                    .Where(x => x.BrandId == brandId);
            }
        }
    }
}