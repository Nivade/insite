using System;
using System.IO.Ports;
using System.Threading;

namespace Tablet
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
        public ArduinoControllerMain(string portName)
        {
            serialPort.PortName = portName;
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
            if (buffer != null && buffer != "")
            {
                //Console.WriteLine(buffer);
                if (buffer.StartsWith("#") && buffer.IndexOf("%") > 0)
                {

                    buffer = buffer.Remove(0, 1);
                    String[]  abuffer;
                    abuffer = new string[2];
                    abuffer[0] = buffer.Substring(0, buffer.IndexOf('%'));
                    buffer = buffer.Remove(0, abuffer[0].Length + 1); //also remove the % token
                    abuffer[1] = buffer;
                    string tmpbuffer = abuffer[0];
                    buffer = abuffer[1];

                    return tmpbuffer;
                }
                if (!buffer.StartsWith("#") && buffer != "" && buffer != null)
                {
                    buffer = buffer.Remove(0, 1);
                }
            }
            return null;
        }
    }
}