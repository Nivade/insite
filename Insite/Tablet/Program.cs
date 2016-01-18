using System;
using System.Text;
using NativeWifi;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Timers;


namespace Tablet
{
    internal class Program
    {
        private static ArduinoControllerMain controller;
        private static string ssidtest;
        private static string Data;
        private static int timerUpdateFrequency = 30000; // update database every 30 seconds
        private static int scanTimerFrequency = 10000; // scan for wifi networks every 10 seconds
        private static System.Threading.Timer scanner = new System.Threading.Timer(scanner_tick, null, 0, scanTimerFrequency);
        private static System.Timers.Timer DataTimer = new System.Timers.Timer(timerUpdateFrequency);
        private static bool quit = false;
        private static string received;

        private static WlanClient client = new WlanClient();
        /*[STAThread]*/



        private static void Main(string[] args)
        {
            // Get all available ports, so you know where you can choose from
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine("The following serial ports were found:");
            foreach (string port in ports)
            {
                Console.Write(port + ";");
            }
            Console.WriteLine(); // So the next text will start on a new line
            Console.WriteLine("Input the port number of the arduino.");
            string portNumber = Console.ReadLine();
            controller = new ArduinoControllerMain("COM" + portNumber);
            controller.SendData("RESET");
            string ownMac = client.Interfaces[0].NetworkInterface.GetPhysicalAddress().ToString();
            Console.WriteLine("Own MAC Address = " + ownMac);
            while (controller.ReceivedData() != "GET_ID") ;
            Console.WriteLine("Voer een netwerknaam in (e.g. fontysWPA): ");

            ssidtest = Console.ReadLine();
            {
                int length = ssidtest.Length;
                for (int i = 0; i < (32 - length); i++)
                {
                    ssidtest += '\0';
                }
            }

            DataTimer.Elapsed += OnTimedEvent;
            DataTimer.Start();
            controller.SendData("id:" + ownMac);
            Thread.Sleep(5000);
            OnTimedEvent(null, null);


            while (!quit)
            {
                Thread.Sleep(5000);
                //OnTimedEvent(null, null);
            }
        }



        private static void scanner_tick(object state)
        {
            foreach (WlanClient.WlanInterface interfacetoscan in client.Interfaces)
            {
                interfacetoscan.Scan();
            }
        }



        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            WifiDetection(client);

            while (received == null)
            {
                received = controller.ReceivedData();
            }

            if (received != null)
            {
                Console.WriteLine(received);
                if (received.Contains(";"))
                {
                    if (received.StartsWith("NETWORK:"))
                    {
                        //Console.WriteLine(received);
                        received = received.Remove(0, 8);
                        string[] addressen = received.Split(';');
                        string ownMac = addressen[0];
                        string RoomMac = addressen[1];
                        

                        Database.AddDataToDB(ownMac, RoomMac);

                        received = null;
                    }
                }
            }

        }



        private static void WifiDetection(WlanClient client)
        {
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {

                Wlan.WlanBssEntry[] wlanBssEntries = wlanIface.GetNetworkBssList();

                foreach (Wlan.WlanBssEntry network in wlanBssEntries)
                {
                    int rss = network.rssi;
                    byte[] macAddr = network.dot11Bssid;
                    string tMac = "";

                    for (int i = 0; i < macAddr.Length; i++)
                    {

                        tMac += macAddr[i].ToString("x2").PadLeft(2, '0').ToUpper();

                    }
                    string SSID = Encoding.ASCII.GetString(network.dot11Ssid.SSID).ToString();

                    if (ssidtest == SSID)
                    {

                        Data += network.linkQuality;
                        Data += ";";
                        Data += tMac;
                        Data += ";";
                    }
                }
            }
            //Console.WriteLine(Data);
            controller.SendData(Data);
            Data = null;
        }

    }

}