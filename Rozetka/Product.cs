using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozetka
{
    public class Product
    {
        [JsonProperty]
        private int ProductId { get; set; }
        [JsonProperty]
        private string Name { get; set; }
        [JsonProperty]
        private decimal Price { get; set; }

        public Product(int productId, string name, decimal price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public int GetProductId()
        {
            return ProductId;
        }

        public string GetName()
        {
            return Name;
        }

        public decimal GetPrice()
        {
            return Price;
        }
    }
}
