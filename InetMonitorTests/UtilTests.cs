using InetMonitor.BAL;
using System;
using Xunit;

namespace InetMonitorTests
{
  public class UtilTests
  {
    [Fact]
    public void IsTopOfMinute_ZeroSecondShouldReturnTrue()
    {
      // Arrange
      DateTime dtToTest = new DateTime(2019, 03, 22, 6, 0, 0); // 6:00.00am

      // Act
      bool result = Util.IsTopOfMinute(dtToTest);

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void IsTopOfMinute_OneSecondShouldReturnFalse()
    {
      // Arrange
      DateTime dtToTest = new DateTime(2019, 03, 22, 6, 0, 1); // 6:00.01am

      // Act
      bool result = Util.IsTopOfMinute(dtToTest);

      // Assert
      Assert.False(result);
    }

    [Fact]
    public void IsTopOfMinute_FiftyNineSecondShouldReturnFalse()
    {
      // Arrange
      DateTime dtToTest = new DateTime(2019, 03, 22, 5, 59, 59); // 5:59.59am

      // Act
      bool result = Util.IsTopOfMinute(dtToTest);

      // Assert
      Assert.False(result);
    }

    [Fact]
    public void ValidateIp_RandomStringShouldReturnFalse()
    {
      // Arrange
      string toTest = "~!~!#$%^&a;sdlkfj;kj;";

      // Act
      bool result = Util.IsValidIp(toTest);

      // Assert
      Assert.False(result);
    }

    [Fact]
    public void ValidateIp_OutsideIpShouldReturnFalse()
    {
      // Arrange
      string toTest = "256.256.256.256";

      // Act
      bool result = Util.IsValidIp(toTest);

      // Assert
      Assert.False(result);
    }

    [Fact]
    public void ValidateIp_SampleValidIpShouldReturnTrue()
    {
      // Arrange
      string toTest = "192.168.1.1";

      // Act
      bool result = Util.IsValidIp(toTest);

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void ValidateIp_RandomIpShouldReturnSameIp()
    {
      // Arrange
      Random rnd = new Random();
      int a = rnd.Next(1, 256); // creates a number between 1 and 255
      int b = rnd.Next(1, 256); // creates a number between 1 and 255
      int c = rnd.Next(1, 256); // creates a number between 1 and 255
      int d = rnd.Next(1, 256); // creates a number between 1 and 255

      // Act
      string toTest = string.Format("{0}.{1}.{2}.{3}", a, b, c, d);
      bool result = Util.IsValidIp(toTest);

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void ReplaceDots_StringWithDotsShouldBeReplacedWithUnderscore()
    {
      // Arrange
      string toTest = "192.168.1.1";

      // Act
      string result = Util.ReplaceDots(toTest);

      // Assert
      Assert.Equal("192_168_1_1", result);
    }

    [Fact]
    public void ReplaceDots_NoDotsShouldHaveNoChange()
    {
      // Arrange
      string toTest = "Mary had a little lamb";

      // Act
      string result = Util.ReplaceDots(toTest);

      // Assert
      Assert.Equal(toTest, result);
    }
  }
}
