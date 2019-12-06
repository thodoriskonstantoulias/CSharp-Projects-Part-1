using System;
using System.IO;

namespace WordUnscrambler.Workers
{
    public class FileReader
    {
        public string[] Read(string filename)
        {
            string[] wordsFromFile;
            try
            {
                wordsFromFile = File.ReadAllLines(filename);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         
            return wordsFromFile;
        }
    }
}
