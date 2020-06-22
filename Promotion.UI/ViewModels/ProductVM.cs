using Promotion.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promotion.ViewModels
{
    public class ProductVM
    {
        public List<Product> products { get; set; } = new List<Product>();
        public List<Discount> discounts { get; set; } = new List<Discount>();
        public List<CartSummary> CartSummary { get; set; } = new List<CartSummary>();
    }
}
