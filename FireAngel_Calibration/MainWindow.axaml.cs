using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Metsys.Bson.Configuration;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Configuration.Json;
namespace FireAngel_Calibration
{
    public partial class MainWindow : Window
    {
        public IConfigurationRoot _Configuration { get; set; }
        public static MainWindow? Instance { get; private set; }

        public MainWindow()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _Configuration = builder.Build();
            var myFirstClass = _Configuration.GetSection("Protocols").Get<List<Protocol>>();//Configuration.GetSection("Protocols") as Protocols;
            foreach (var x in myFirstClass)
            {
                Console.WriteLine($"{x.Name}, {x.ProtocolHandler}, {x.CommandSize}");
                foreach (var y in x.CommandSet)
                {
                    
                    //Console.WriteLine($"/t{y.Name} => {y.GetValue(x)}");
                }
            }
            InitializeComponent();
        }
    }

    class ProtocolCommand
    {
        public String Description { get; set; }
        public Byte CommandId { get; set; }
        public UInt16 TxDataSize { get; set; }
        public UInt16 RxDataSize { get; set; }
        public Boolean XModem { get; set; }
    }
    
    class Protocol
    {
        public String Name { get; set; }
        public String ProtocolHandler { get; set; }
        public UInt16 CommandSize { get; set; }
        public List<ProtocolCommand> CommandSet {get;set;}
    }

    class Protocols
    {
        public List<Protocol> ProtocolList { get; set; }
    }
}