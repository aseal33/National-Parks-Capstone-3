using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal balance = 0;
            VendingMachine vendingMachine = new VendingMachine();

            while (true)
            {
                Console.WriteLine("\nWelcome to the VendoMatic 4000: Select Option Below");

                Console.Write("(1) View Inventory \n(2) Select Product \n(3) Quit\n");
                Console.Write($"> Current Balance: ${balance} \n>>:");
                string menu = Console.ReadLine();
                Console.WriteLine("");

                if (menu == "1")
                {
                    vendingMachine.DisplayItems();
                    Console.WriteLine("");
                }
                else if (menu == "2")
                {
                    bool valid = false;

                    do
                    {
                        Console.Write("> Please enter the location of the product you'd like to puchase: ");
                        string input = Console.ReadLine().ToUpper();


                        if (vendingMachine.inventory.ContainsKey(input))
                        {
                            Product product = vendingMachine.inventory[input];

                            if (product.Quantity > 0)
                            {
                                Console.Write($"\n> Price of item selected : ${product.Price} \n\n > {product.Quantity} Remaining\n");

                                bool run = true;

                                while (run)
                                {
                                    Console.WriteLine($"\n> Current Balance is ${balance}\n\n> Please Enter a Whole Dollar Amount(1, 2, 5, 10), (d) to dispence or (s) to start over");
                                    string input2 = Console.ReadLine();

                                    if (input2 == "1" || input2 == "2" || input2 == "5" || input2 == "10")
                                    {
                                        int amount = int.Parse(input2);
                                        balance += (decimal)amount;

                                        Console.WriteLine($"> ${input2} inserted.");
                                        using (StreamWriter sw = new StreamWriter("log.txt", true))
                                        {
                                            sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} FEED MONEY: ${amount}     ${balance}");
                                        }

                                    }
                                    else if (input2 == "D" || input2 == "d")
                                    {
                                        if (balance >= product.Price)
                                        {
                                            run = false;
                                            vendingMachine.DispenseProduct(input);
                                            using (StreamWriter sw = new StreamWriter("log.txt", true))
                                            {
                                                sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} {product.Name} {product.Location} ${balance}     ${balance - product.Price}");
                                            };
                                            balance -= product.Price;
                                        }
                                        else
                                        {
                                            Console.WriteLine("> Insufficient Funds, please add more money.");
                                        }
                                    }
                                    else if (input2 == "S" || input2 == "s")
                                    {
                                        Console.WriteLine("");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("> Invalid Entry. Please enter valid input.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n>>Sorry that item is SOLD OUT<<\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("> Invalid Entry. Please enter valid input.");
                            valid = true;
                        }
                    } while (valid);
                }
                else if (menu == "3")
                {
                    Console.WriteLine("> Thank You for using VendoMatic 4000!");
                    Console.WriteLine($"> Your remaining balance is: ${balance}");

                    using (StreamWriter sw = new StreamWriter("log.txt", true))
                    {
                        sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} GIVE CHANGE: ${balance}     $0.00");
                    };
                    int numQuarter = 0;
                    int numDime = 0;
                    int numNickel = 0;

                    while (balance > 0)
                    {
                        if (balance >= 0.25M)
                        {
                            numQuarter++;
                            balance -= 0.25M;
                        }
                        else if (balance >= 0.10M)
                        {
                            numDime++;
                            balance -= 0.10M;
                        }
                        else if (balance >= 0.50M)
                        {
                            numNickel++;
                            balance -= 0.05M;
                        }
                    }

                    Console.Write($"> Here is your change: {numQuarter} Quarter(s), {numDime} Dime(s), {numNickel} Nickel(s).\n");
                }
                else
                {
                    Console.WriteLine("> Invalid Entry. Please enter valid input.");
                }
            }
        }
    }
}
