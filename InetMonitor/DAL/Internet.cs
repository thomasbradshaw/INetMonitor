using System;
using System.Net.NetworkInformation;

namespace InetMonitor.DAL
{
  class Internet : INetwork
  {
    private readonly Ping pinger;

    public Internet()
    {
      this.pinger = new Ping();
    }

    ~Internet()
    {
      this.pinger.Dispose();
    }

    public PingReply Ping(String url)
    {
      return pinger.Send(url);
    }
  }
}
