using System.Net.NetworkInformation;

namespace InetMonitor.DAL
{
  public interface INetwork
  {
    PingReply Ping(string url);
  }
}
