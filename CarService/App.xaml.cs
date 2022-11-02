using AutoMapper;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace CarService
{
    public partial class App : Application
    {
        public static IMapper? Mapper { get; set; }

        public App()
        {
            var documentsFolderLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Car Service LITE";
            Directory.CreateDirectory(documentsFolderLocation);

            var textWriterTraceListener = new TextWriterTraceListener($"{documentsFolderLocation}\\CarService.log")
            {
                TraceOutputOptions = TraceOptions.DateTime
            };

            Trace.Listeners.Clear();
            Trace.Listeners.Add(textWriterTraceListener);
            Trace.AutoFlush = true;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(App));
            });

            Mapper = new Mapper(config);
        }
    }
}