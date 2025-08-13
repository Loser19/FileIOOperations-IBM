using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOOperationsIBM
{
    internal class ProdLINQ
    {
        List<Prod> prods = new List<Prod>
        {
            new Prod(1, "Laptop", 1200.50, DateTime.Now),
            new Prod(2, "Smartphone", 800.00, DateTime.Now),
            new Prod(3, "Tablet", 300.75, DateTime.Now),
            new Prod(4, "Smartwatch", 250.00, DateTime.Now),
            new Prod(5, "Headphones", 150.00, DateTime.Now)
        };

        // LINQ queries

        public void BasicLinq() // show all products using LINQ
        {
            var result = from p in prods
                       select p;
            Console.WriteLine("Using LINQ to show all products:");
            foreach (var p in result)
            {
                Console.WriteLine($"ID: {p.productId}, Name: {p.productName}, Price: {p.productPrice}, Date: {p.productDate}");
            }
            Console.WriteLine();
        }

        public void WhereLinq()
        {
            Console.WriteLine("Using Where in LINQ: ");
            var result = prods.Where(p => p.productPrice > 200);
            foreach (var p in result)
            {
                Console.WriteLine($"ID: {p.productId}, Name: {p.productName}, Price: {p.productPrice}, Date: {p.productDate}");
            }
            Console.WriteLine();
        }

        public void TakeWhileLinq()
        {
            Console.WriteLine("Using TakeWhile in LINQ: ");
            var result = prods.TakeWhile(p => p.productPrice > 200);
            foreach (var p in result)
            {
                Console.WriteLine($"ID: {p.productId}, Name: {p.productName}, Price: {p.productPrice}, Date: {p.productDate}");
            }
            Console.WriteLine();
        }

        public void TakeLinq()
        {
            Console.WriteLine("Using Take in LINQ: ");
            var result = prods.Take(3);
            foreach (var p in result)
            {
                Console.WriteLine($"ID: {p.productId}, Name: {p.productName}, Price: {p.productPrice}, Date: {p.productDate}");
            }
            Console.WriteLine();
        }
        public void LinqFirstorFirstDeafault()
        {
            Console.WriteLine("Using First and FirstOrDefault in LINQ: ");
            var firstProduct = prods.First();
            Console.WriteLine($"First Product: ID: {firstProduct.productId}, Name: {firstProduct.productName}, Price: {firstProduct.productPrice}, Date: {firstProduct.productDate}");
            var firstOrDefaultProduct = prods.FirstOrDefault(p => p.productName == "Smartphone");
            if (firstOrDefaultProduct == null)
            {
                Console.WriteLine("No product found with the specified condition.");
            }
            else
            {
                Console.WriteLine($"First Or Default Product: ID: {firstOrDefaultProduct.productId}, Name: {firstOrDefaultProduct.productName}, Price: {firstOrDefaultProduct.productPrice}, Date: {firstOrDefaultProduct.productDate}");
            }
            Console.WriteLine();
        }
        public void LinqSingleorSingleDeafult()
        {
            Console.WriteLine("Using Single and SingleOrDefault in LINQ: ");
            try
            {
                var singleProduct = prods.Single(p => p.productId == 1);
                Console.WriteLine($"Single Product: ID: {singleProduct.productId}, Name: {singleProduct.productName}, Price: {singleProduct.productPrice}, Date: {singleProduct.productDate}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Multiple products found with the specified condition.");
            }
            var singleOrDefaultProduct = prods.SingleOrDefault(p => p.productName == "NonExistentProduct");
            if (singleOrDefaultProduct == null)
            {
                Console.WriteLine("No product found with the specified condition.");
            }
            Console.WriteLine();
        }
        public void GroupByLinq()
        {
            Console.WriteLine("Using GroupBy in LINQ: ");
            var groupedProducts = prods.GroupBy(p => p.productPrice > 500 ? "Expensive" : "Affordable");
            foreach (var group in groupedProducts)
            {
                Console.WriteLine($"{group.Key} Products:");
                foreach (var p in group)
                {
                    Console.WriteLine($"ID: {p.productId}, Name: {p.productName}, Price: {p.productPrice}, Date: {p.productDate}");
                }
            }
            Console.WriteLine();
        }
        public void GroupByIntoLinq()
        {
            Console.WriteLine("Using GroupBy with Into in LINQ: ");
            var groupedProducts = prods.GroupBy(p => p.productPrice > 500 ? "Expensive" : "Affordable")
                                       .Select(g => new
                                       {
                                           Category = g.Key,
                                           Products = g.ToList()
                                       });
            foreach (var group in groupedProducts)
            {
                Console.WriteLine($"{group.Category} Products:");
                foreach (var p in group.Products)
                {
                    Console.WriteLine($"ID: {p.productId}, Name: {p.productName}, Price: {p.productPrice}, Date: {p.productDate}");
                }
            }
            Console.WriteLine();
        }
        public void OrderByThenByLinq()
        {
            Console.WriteLine("Using OrderBy and ThenBy in LINQ: ");
            var orderedProducts = prods.OrderBy(p => p.productPrice).ThenBy(p => p.productName);
            foreach (var p in orderedProducts)
            {
                Console.WriteLine($"ID: {p.productId}, Name: {p.productName}, Price: {p.productPrice}, Date: {p.productDate}");
            }
            Console.WriteLine();
        }
        public void OrderByLinq()
        {
            Console.WriteLine("Using OrderBy in LINQ: ");
            var orderedProducts = prods.OrderBy(p => p.productPrice);
            foreach (var p in orderedProducts)
            {
                Console.WriteLine($"ID: {p.productId}, Name: {p.productName}, Price: {p.productPrice}, Date: {p.productDate}");
            }
            Console.WriteLine();
        }


    }
}
