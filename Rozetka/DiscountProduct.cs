using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozetka
{
    public class DiscountProduct : Product
    {
        private decimal Discount { get; set; }

        public DiscountProduct(int productId, string name, decimal price, decimal discount)
            : base(productId, name, price)
        {
            Discount = discount;
        }

        public decimal GetDiscount()
        {
            return Discount;
        }
    }
}
