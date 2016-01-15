using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace Insite
{
    class ArduinoControllerMain
    {
        private SerialPort serialPort = new SerialPort();
        Timer datagetter;

        private string buffer { get; set; }

        void datagetter_tick(object state)
        {

            try
            {
                if (serialPort.BytesToRead > 0)
                {
                    buffer += serialPort.ReadExisting();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public ArduinoControllerMain()
        {
            serialPort.PortName = "COM3";
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;

            datagetter = new Timer(datagetter_tick, null, 5000, 100);

            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        public void SendData(string data)
        {
            serialPort.Write("#" + data + "%");
        }
        public string ReceivedData()
        {
            if (buffer != null)
            {

                if (buffer.StartsWith("#") && buffer.IndexOf("%") > 0)
                {

                    buffer = buffer.Remove(0, 1);
                    buffer = buffer.Remove(buffer.IndexOf('%'));
                    string tmpbuffer = buffer;
                    buffer = "";

                    return tmpbuffer;
                }
                if (!buffer.StartsWith("#") && buffer != "")
                {
                    buffer = buffer.Remove(0, 1);

                }
            }
            return null;

        }
    }
}