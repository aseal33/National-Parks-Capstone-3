using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Product
    {
        public string Name { get; }
        public string Location { get; }
        public decimal Price { get; }
        public string Type { get; }
        public int Quantity { get; set; }

        public Product(string location, string name, decimal price, string type)
        {
            this.Name = name;
            this.Location = location;
            this.Price = price;
            this.Type = type;
            this.Quantity = 5;
        }       
    }
}
