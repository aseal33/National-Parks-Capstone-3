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

        // ADDED THIS PROPERTY TO KEEP TRACK OF THE SALES FOR SALES REPORT
        // Nothing else ever checks this. It doesn't show up anywhere else
        public int Sold { get; set; }

        public Product(string location, string name, decimal price, string type)
        {
            this.Name = name;
            this.Location = location;
            this.Price = price;
            this.Type = type;
            this.Quantity = 5;

            // Starts at 0 and increments with each sale
            this.Sold = 0;
        }
    }
}
