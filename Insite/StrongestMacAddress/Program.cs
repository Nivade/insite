using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NativeWifi;

namespace StrongestMacAddress
{
    class Program
    {
        static string Data;
        static void Main(string[] args)
        {
            Console.WriteLine("Input ssid:");
            string ssid = Console.ReadLine();
            int length = ssid.Length;
            // This is for the comparison between ssids. The ssid length is always 32, so this one also has to be that long.
            for (int i = 0; i < (32 - length); i++)
            {
                ssid += '\0';
            }
            WlanClient client = new WlanClient();
            begin:
            WifiDetection(client, ssid);
            System.Threading.Thread.Sleep(5000);
            goto begin;
        }

        private static void WifiDetection(WlanClient client, string ssid)
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

                    if (ssid == SSID)
                    {

                        Data += network.linkQuality;
                        Data += ";";
                        Data += tMac;
                        Data += ";";
                    }
                }
            }
            Console.WriteLine("data: " + Data);
            Data = null;
        }
    }
}
