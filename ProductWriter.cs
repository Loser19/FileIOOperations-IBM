using System;
using System.IO;

namespace FileIOOperationsIBM
{
    public class ProductWriter
    {
        private string _filePath;

        public ProductWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void WriteProduct(Product product)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath, true))
                {
                    writer.WriteLine($"{product.ProductId},{product.ProductName},{product.ProductPrice}");
                }
                Console.WriteLine("Product written successfully.");
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
