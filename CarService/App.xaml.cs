using AutoMapper;
using System.Windows;

namespace CarService
{
    public partial class App : Application
    {
        public static IMapper? Mapper { get; set; }

        public App()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(App));
            });

            Mapper = new Mapper(config);
        }
    }
}