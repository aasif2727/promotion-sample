using Promotion.Data.Entities;
using Promotion.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promotion.Service
{
    public class MemoryProvider : InMemoryProvider
    {
        public IQueryable<Product> AllProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { ProductId = 1, Title = "A", UnitPrice = 50, IsActive = true });
            products.Add(new Product() { ProductId = 2, Title = "B", UnitPrice = 30, IsActive = true });
            products.Add(new Product() { ProductId = 3, Title = "C", UnitPrice = 20, IsActive = true });
            products.Add(new Product() { ProductId = 4, Title = "D", UnitPrice = 15, IsActive = true });
            return products.AsQueryable();
        }

        public IQueryable<Discount> AllDiscounts()
        {
            List<Discount> promotions = new List<Discount>();
            promotions.Add(new Discount() { DiscountId = 1, DiscountRule = "A", DiscountPercentage = 13.33, MinQty = 3,IsActive = true });
            promotions.Add(new Discount() { DiscountId = 2, DiscountRule = "B", DiscountPercentage = 25, MinQty = 2, IsActive = true });
            promotions.Add(new Discount() { DiscountId = 3, DiscountRule = "C+D", DiscountPercentage = 14.28, MinQty = 1, IsActive = true });
            return promotions.AsQueryable();
        }
    }
}
