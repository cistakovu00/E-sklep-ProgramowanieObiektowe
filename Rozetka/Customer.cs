using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozetka
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public Cart Cart { get; set; }

        public Customer(int customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
            Cart = new Cart();
        }

        public void PlaceOrder()
        {
            decimal total = Cart.CalculateTotal();
            Console.WriteLine($"Customer: {Name}, Total Order Value: {total}");
        }

        public void SerializeToJson(Customer customer)
        {
            customer.Cart.Products = Cart.DeserializeFromJson();
            string customerJson = JsonConvert.SerializeObject(customer);
            string fileName = String.Concat(customer.Name, ".json");
            File.WriteAllText(fileName, customerJson);
            Console.WriteLine($"Customer saved to {fileName}");
        }

        public static Customer DeserializeFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                string customerJson = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Customer>(customerJson);
            }
            else
            {
                return null;
            }
        }
    }
}
