using NUnit.Framework;
using Promotion.Data.Entities;
using Promotion.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promotion.Tests
{
    public class ProductServiceTests
    {
        public ProductService productService = null;
        public ProductServiceTests()
        {
            productService = new ProductService(new MemoryProvider());
        }

        [Test, Order(1)]
        [TestCase(1,"A",50, 5)]
        [TestCase(2, "B", 30, 5)]
        public void Get_Discounted_Proce(int productId,string productTitle,double unitPrice, int qty)
        {
            Product product = new Product() { ProductId = productId, Title = productTitle, UnitPrice = unitPrice, Qty = qty };
            List<Product> products = productService.GetProducts().ToList();
            var results = productService.GetDiscountedPrice(product, products, null);
            Assert.IsNotNull(results);
            Assert.IsInstanceOf<double>(results);
        }
    }
}
