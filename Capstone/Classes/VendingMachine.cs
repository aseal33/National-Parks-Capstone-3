using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public VendingMachine()
        {
            List<Product> products = new List<Product>();

            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] separated = line.Split("|");

                    
                    Product product = new Product(separated[1], separated[0], decimal.Parse(separated[2]), separated[3]);
                    products.Add(product);
                }
            }
        }
    }
}
