using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOOperationsIBM
{
    public class FileWriter
    {
        private string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void WriteToFile(string content)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    writer.WriteLine(content);
                }

                Console.WriteLine("Text written successfully.");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Access denied: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("IO error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}