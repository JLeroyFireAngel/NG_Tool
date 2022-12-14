using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NG_Commander.ViewModels;

public class ProductProtocolCommandViewModel : ObservableObject
{
    public string? Name          { get; set; }
    public UInt16  Command       { get; set; }
    public string? Unit          { get; set; }
    public float   Multiplier    { get; set; } = 1.0f;
    public UInt32  Timeout_ms    { get; set; } = 0;
    public String  TxValueString { get; set; } = "";
    public object? TxValue       { get; set; }
    public object? RxValue       { get; set; }

    public bool HasTxData => TxValue != null;
    
    public Int32 BaudRate { get; set; }
    public Int32 Parity   { get; set; }
    public Int32 DataBits { get; set; }
    public Int32 StopBits { get; set; }
}