using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOOperationsIBM
{
    internal class Prod
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
        public DateTime productDate { get; set; }

        public Prod() { }
        public Prod(int id, string name, double price, DateTime date)
        {
            productId = id;
            productName = name;
            productPrice = price;
            productDate = date;
        }
    }
}
