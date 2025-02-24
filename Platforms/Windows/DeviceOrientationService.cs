using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service;
public partial class DeviceOrientationService
{
    SerialPort? mySerialPort;
    public partial void OpenPort()
    {
        if(mySerialPort != null)
        {
            try
            {
                if (mySerialPort.IsOpen) mySerialPort.Close();
                mySerialPort.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la fermeture du port: {ex.Message}");
            }
            finally
            {
                mySerialPort = null;
            }
        }else
        {
            mySerialPort = new SerialPort
            {
                BaudRate = 9600,
                PortName = "COM3",
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                ReadTimeout = 10000,
                WriteTimeout = 10000                
            };

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataHandler);

            try
            {
                mySerialPort.Open();
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error!", ex.ToString(), "OK");
            }
        }            
    }

    public partial void ClosePort()
    {
        if (mySerialPort != null && mySerialPort.IsOpen)
        {
            try
            {
                mySerialPort.Close();
                mySerialPort.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la fermeture du port: {ex.Message}");
            }
            finally
            {
                mySerialPort = null;
            }
        }        
    }
    private void DataHandler(object sender,EventArgs arg )
    { 
        SerialPort sp = (SerialPort)sender;        

        SerialBuffer.Enqueue(sp.ReadExisting());
    }
}
