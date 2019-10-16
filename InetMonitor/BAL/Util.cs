using System;
using System.Net;

namespace InetMonitor.BAL
{
  public static class Util
  {
    public static bool IsValidIp(string ipToTest)
    {
      return IPAddress.TryParse(ipToTest, out _);
    }

    public static string ReplaceDots(string ip)
    {
      return ip.Replace(".", "_");
    }

    public static bool IsTopOfMinute(DateTime dt)
    {
      return dt.Second == 0;
    }
  }
}
