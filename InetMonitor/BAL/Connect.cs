using InetMonitor.DAL;
using System;
using System.Net.NetworkInformation;

namespace InetMonitor.BAL
{
  public class Connect
  {
    private INetwork Network { get; set; }
    private IWriter Writer { get; set; }

    public Connect(INetwork network, IWriter writer)
    {
      this.Network = network;
      this.Writer = writer;
    }

    public void Ping(string url)
    {
      PingReply pr = Network.Ping(url);
      if (pr != null)
      {
        Record(string.Format("{0} Pinging {1} - {2}", DateTime.Now, url, pr.Status.ToString()));
      }
      else
      {
        throw new Exception("No ping response");
      }
    }

    private void Record(string lineToWrite)
    {
      Console.WriteLine(lineToWrite);
      Writer.WriteOut(lineToWrite);
    }
  }
}
