using System;
using System.IO;


namespace WordUnscrambler.Workers
{
    public class FileReader
    {
        public string[] Read(string fileName)
        {
            string[] fileContents;

            try
            {
                fileContents = File.ReadAllLines(fileName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return fileContents;
        }
    }
}
