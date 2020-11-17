namespace SampleProject.Data
{
    using System;
    using System.IO;

    public class FileLogger : IFileLogger
    {
        public void AddEntry(string logDetails) {
            string path = @"C:\Logger.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                File.AppendAllText(path, logDetails + Environment.NewLine);
                tw.Close();
            }
            else
            {
                using(var tw = new StreamWriter(path, true))
                {
                    File.AppendAllText(path, logDetails + Environment.NewLine);
                } 
            }
        }
    }
}
