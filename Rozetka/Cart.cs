using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozetka
{
    public class Cart
    {
        public List<Product> Products = new List<Product>();

        private static string JsonFileName = "cart.json";

        public void AddProduct(Product product)
        {
            Products = DeserializeFromJson();
            Products.Add(product);
            SerializeToJson(Products);
        }

        public void DisplayCart()
        {
            Products = DeserializeFromJson();
            foreach (var product in Products)
            {
                Console.WriteLine($"Product ID: {product.GetProductId()}, Name: {product.GetName()}, Price: {product.GetPrice()}");
            }
        }

        public decimal CalculateTotal()
        {
            Products = DeserializeFromJson();
            return Products.Sum(product => product.GetPrice());
        }

        public static List<Product> DeserializeFromJson()
        {
            if (File.Exists(JsonFileName))
            {
                string productsJson = File.ReadAllText(JsonFileName);
                return JsonConvert.DeserializeObject<List<Product>>(productsJson);
            }
            else
            {
                return new List<Product>();
            }
        }

        public void SerializeToJson(List<Product> productList)
        {
            string productsJson = JsonConvert.SerializeObject(productList);
            File.WriteAllText(JsonFileName, productsJson);
            Console.WriteLine($"Products saved to {JsonFileName}");
        }
    }
}
