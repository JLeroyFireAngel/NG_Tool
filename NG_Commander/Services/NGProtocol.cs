using System;
using RJCP.IO.Ports;

namespace NG_Commander.Services;

public class NGProtocol : IDisposable
{
    private SerialPortStream m_SerialPortStream = new ();
    
    public NGProtocol()
    {
        
    }
    //public void Send(UInt16 CommandId)
    public void Dispose()
    {
        m_SerialPortStream.Close();
    }
}