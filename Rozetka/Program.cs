using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozetka
{
    internal class Program
    {
        private static Cart cart = new Cart();
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();
            Customer customer = new Customer(1, customerName);

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Product to Cart");
                Console.WriteLine("2. Display Cart");
                Console.WriteLine("3. Calculate Total");
                Console.WriteLine("4. Place Order");
                Console.WriteLine("5. Save Customer");
                Console.WriteLine("0. Exit");

                string choice = Console.ReadLine();

                if (Enum.TryParse(choice, out MenuChoices menuChoice))
                {
                    switch (menuChoice)
                    {
                        case MenuChoices.AddProduct:
                            AddNewProduct();
                            break;
                        case MenuChoices.DisplayCart:
                            cart.DisplayCart();
                            break;
                        case MenuChoices.CalculateTotal:
                            CalculatingTotal();
                            break;
                        case MenuChoices.PlaceOrder:
                            customer.PlaceOrder();
                            break;
                        case MenuChoices.SaveCustomer:
                            customer.SerializeToJson(customer);
                            break;
                        case MenuChoices.Exit:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        private static void CalculatingTotal()
        {
            decimal total = cart.CalculateTotal();
            Console.WriteLine($"Total: {total}");
        }

        private static void AddNewProduct()
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            decimal productPrice = decimal.Parse(Console.ReadLine());
            Product product = new Product(productId, productName, productPrice);
            cart.AddProduct(product);
        }
    }
}
