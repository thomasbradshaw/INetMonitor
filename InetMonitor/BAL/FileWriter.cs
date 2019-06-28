using System.IO;

namespace InetMonitor.BAL
{
    public class FileWriter : IWriter
    {
        private string destinationFile;

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
