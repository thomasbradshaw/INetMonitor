using System.IO;

namespace InetMonitor.DAL
{
  public class FileWriter : IWriter
  {
    private readonly string destinationFile;

    public FileWriter(string destinationFile)
    {
      this.destinationFile = destinationFile;
    }

    public void WriteOut(string lineToWrite)
    {
      var file = File.AppendText(destinationFile);
      file.WriteLine(lineToWrite);
      file.Close();
    }
  }
}
