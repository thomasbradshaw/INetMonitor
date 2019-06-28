using System;
using System.Net.NetworkInformation;

namespace InetMonitor.BAL
{
    public class IpConnect : IConnect
    {
        private string Url { get; set; }
        private IWriter Writer { get; set; }

        public IpConnect(string url, IWriter writer)
        {
            this.Url = url;
            this.Writer = writer;
        }

        public void Ping()
        {
            DateTime dt = DateTime.Now;

            Ping pinger = new Ping();
            PingReply pr = pinger.Send(Url);

            Record(string.Format("{0} Pinging {1} - {2}", dt, Url, pr.Status.ToString()));
            pinger.Dispose();
        }

        private void Record(string lineToWrite)
        {
            Console.WriteLine(lineToWrite);
            Writer.WriteOut(lineToWrite);
        }
    }
}
