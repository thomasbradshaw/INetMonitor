using InetMonitor.BAL;
using InetMonitor.DAL;
using Moq;
using System;
using System.IO;
using System.Net.NetworkInformation;
using Xunit;

namespace InetMonitorTests
{
  public class ConnectTests
  {
    private readonly Connect _connect;

    public ConnectTests()
    {
      var networkMock = new Mock<INetwork>();
      networkMock.Setup(x => x.Ping(GetRandomString())).Returns((PingReply)null);
      var writerMock = new Mock<IWriter>();
      _connect = new Connect(networkMock.Object, writerMock.Object);
    }

    /// <summary>
    /// Used to generate a mock IP --> random string ok
    /// </summary>
    /// <returns></returns>
    private static string GetRandomString()
    {
      string path = Path.GetRandomFileName();
      path = path.Replace(".", ""); // Remove period.
      return path;
    }

    [Fact]
    public void Ping_BadIpThrowsException()
    {
      // Arrange
      string randomIp = GetRandomString();

      // Act & Assert
      var ex = Assert.Throws<Exception>(() => _connect.Ping(randomIp));
      Assert.Equal("No ping response", ex.Message);
    }
  }
}
