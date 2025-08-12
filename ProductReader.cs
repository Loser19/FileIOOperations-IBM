using System;
using System.IO;

namespace FileIOOperationsIBM
{
    public class ProductReader
    {
        private string _filePath;

        public ProductReader(string filePath)
        {
            _filePath = filePath;
        }

        public void ReadProducts()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("File not found.");
                    return;
                }
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found: " + e.Message);
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