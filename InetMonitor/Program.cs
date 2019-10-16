using InetMonitor.BAL;
using InetMonitor.DAL;
using System;

namespace InetMonitor
{
  public class Program
  {
    static void Main(string[] args)
    {
      if (args.Length > 0 && Util.IsValidIp(args[0]))
      {
        string ip = args[0];
        INetwork network = new Internet();
        IWriter fileWriter = new FileWriter(string.Format("{0}\\{1}_PingLog.txt", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Util.ReplaceDots(ip)));
        Connect connection = new Connect(network, fileWriter);

        bool isCalled = false;
        while (true)
        {
          if (Util.IsTopOfMinute(DateTime.Now))
          {
            if (!isCalled)
            {
              connection.Ping(ip);
              isCalled = true;
            }
          }
          else
          {
            isCalled = false;
          }
        }
      }
      else
      {
        Console.WriteLine("Unable to run - Bad IP");
      }
    }
  }
}
