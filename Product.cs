using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOOperationsIBM
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public Product() { }

        public Product(int productId, string productName, decimal productPrice)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Price: {ProductPrice:C}");
        }

        // Write a method to write Product details to a file using StreamWriter.
        public void AddProduct(Product product, string filepath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine($"{product.ProductId},{product.ProductName},{product.ProductPrice}");
                }
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

        // Read Product details from a file using StreamReader.
        public void ReadProducts(string filepath)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    Console.WriteLine("File not found.");
                    return;
                }
                using (StreamReader reader = new StreamReader(filepath))
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