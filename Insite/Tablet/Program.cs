using System;
using System.Text;
using NativeWifi;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Timers;
using Insite;


namespace Tablet
{

    internal class Program
    {

        private static ArduinoControllerMain controller = new ArduinoControllerMain();
        private static string ssidtest;
        private static string Data;
        private static System.Threading.Timer scanner = new System.Threading.Timer(scanner_tick, null, 0, 10000);
        private static System.Timers.Timer DataTimer = new System.Timers.Timer(5000);
        private static bool quit = false;

        private static WlanClient client = new WlanClient();
        /*[STAThread]*/



        private static void Main(string[] args)
        {
            // DataTimer += new ElapsedEventHandler(OnTimedEvent);

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


            // Wlan = new WlanClient();
            while (!quit) {}

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
        }



        private static void WifiDetection(WlanClient client)
        {
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {

                Wlan.WlanBssEntry[] wlanBssEntries = wlanIface.GetNetworkBssList();

                foreach (Wlan.WlanBssEntry network in wlanBssEntries)
                {
                    int rss = network.rssi;

                    //    MessageBox.Show(rss.ToString());
                    byte[] macAddr = network.dot11Bssid;

                    string tMac = "";

                    for (int i = 0; i < macAddr.Length; i++)
                    {

                        tMac += macAddr[i].ToString("x2").PadLeft(2, '0').ToUpper();

                    }
                    string SSID = Encoding.ASCII.GetString(network.dot11Ssid.SSID).ToString();

                    if (ssidtest == SSID)
                    {
                        // Console.WriteLine("Found network with SSID {0}.", SSID);

                        Data += network.linkQuality;
                        Data += ";";

                        //Console.WriteLine("#{0}; ", network.linkQuality);
                        //Console.WriteLine("{0}% ", tMac);
                        Data += tMac;
                        Data += ";";
                    }

                    //Console.WriteLine("BSS Type: {0}.", network.dot11BssType);
                    //System.Windows.Forms.Clipboard.SetText(SSID);
                    //Console.WriteLine("RSSID:{0}", rss.ToString());
                }

                //Console.ReadLine();

                string received = controller.ReceivedData();
                if (received != null)
                {
                    Console.WriteLine(received);
                }
            }
            Console.WriteLine(Data);
            Data = null;

            //    Thread.Sleep(2000);
        }

    }

}
