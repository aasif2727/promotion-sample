using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Data.Entities
{
    public class CartSummary
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public int Qty { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountedPrice { get; set; }
    }
}