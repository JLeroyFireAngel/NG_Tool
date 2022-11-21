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
        private static ToolConfig ToolConfig { get; set; } = new ToolConfig();
        public MainWindow()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _Configuration = builder.Build();
            ToolConfig.ProductProtocols = _Configuration.GetSection("ProductProtocols").Get<List<ProductProtocol>>();
            ToolConfig.LowLevelProtocols = _Configuration.GetSection("LowLevelProtocols").Get<List<LowLevelProtocol>>();//Configuration.GetSection("Protocols") as Protocols;
            foreach (var x in ToolConfig.LowLevelProtocols)
            {
                Console.WriteLine($"{x.Name}");
                foreach (var y in x.NackReasonCodes)
                {
                    Console.WriteLine($"\t{y.Name} - 0x{y.Value:X2}");
                    //Console.WriteLine($"/t{y.Name} => {y.GetValue(x)}");
                }

                foreach (var y in x.Commands)
                {
                    Console.WriteLine($"{y.Group} - 0x{y.GroupCode:X2}__");
                    Console.WriteLine($"{y.GroupCommands.ToString()}");
                }
            }
            
            InitializeComponent();
        }

        private void MnuExit_OnClick(object? sender, RoutedEventArgs e)
        {
            Close();
        }
    }


    public class GroupCommand
    {
        public String Description { get; set; }
        public Byte SubCommandId { get; set; }
        public String TxType { get; set; }
        public String RxType { get; set; }
        public String Unit { get; set; }
        public float Multiplier { get; set; } = 1.0f;
    }
    public class Command
    {
        public String Group { get; set; }
        public Byte GroupCode { get; set; }
        public List<GroupCommand> GroupCommands { get; set; }
    }
    public class NackReasonCode
    {
        public String Name { get; set; }
        public Byte Value { get; set; }
    }
    public class LowLevelProtocol
    {
        public String Name { get; set; }
        public List<NackReasonCode> NackReasonCodes { get; set; }
        public List<Command> Commands { get; set; }

    }

    public class ProductProtocol
    {
        public String Name { get; set; }
        public String ProtocolHandler { get; set; }
        public List<UInt16> CommandSet { get; set; }
    }
    public class ToolConfig
    {
        public List<LowLevelProtocol> LowLevelProtocols { get; set; }
        public List<ProductProtocol> ProductProtocols { get; set; }
    }
}