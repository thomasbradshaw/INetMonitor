using InetMonitor.BAL;
using System;

namespace InetMonitor
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string ipToPing = "8.8.8.8";

            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            IWriter fileWriter = new FileWriter(string.Format("{0}\\PingLog.txt", docFolder));
            IConnect connection = new IpConnect(ipToPing, fileWriter);
            bool isCalled = false;

            while (true)
            {
                if (DateTime.Now.Second == 0)
                {
                    if (!isCalled)
                    {
                        connection.Ping();
                        isCalled = true;
                    }
                }
                else
                {
                    isCalled = false;
                }
            }
        }
    }
}
