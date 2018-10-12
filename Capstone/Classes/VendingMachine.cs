using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        Dictionary<string, Product> inventory = new Dictionary<string, Product>();

        public VendingMachine()
        {
            List<Product> products = new List<Product>();            

            using (StreamReader sr = new StreamReader("input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] separated = line.Split("|");


                    Product product = new Product(separated[0], separated[1], decimal.Parse(separated[2]), separated[3]);
                    products.Add(product);
                }
            }

            foreach (Product item in products)
            {
                inventory.Add(item.Location, item);
            }
        }

        public void DisplayItems()
        {
            foreach (KeyValuePair<string, Product> kvp in inventory)
            {
                Console.WriteLine($"{kvp.Value.Location}|{kvp.Value.Name}|{kvp.Value.Price}|{kvp.Value.Quantity} in stock");
            }
        }

        public void DispenseProduct()
        {
            Console.Write("> Please enter the location of the product you'd like to puchase: ");
            string input = Console.ReadLine();

            if (inventory.ContainsKey(input))
            {
                Product product = inventory[input];

                if (product.Quantity > 0)
                {
                    product.Quantity--;

                    switch (product.Type)
                    {
                        case "Chips":
                            Console.WriteLine("Crunch Crunch, Yum!");
                            break;

                        case "Candy":
                            Console.WriteLine("Munch Munch, Yum!");
                            break;

                        case "Drink":
                            Console.WriteLine("Glug Glug, Yum!");
                            break;

                        case "Gum":
                            Console.WriteLine("Chew Chew, Yum!");
                            break;
                    }

                    using (StreamWriter sw = new StreamWriter("log.txt", true))
                    {
                        sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt")} {product.Name} {product.Location}");
                    };
                }

                else
                {
                    Console.WriteLine("Sorry! That item is out of stock.");
                }
            }

            else
            {
                Console.WriteLine("Invalid Entry");
            }
        }
    }
}
