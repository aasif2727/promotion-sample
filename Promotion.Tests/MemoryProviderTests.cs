using NUnit.Framework;
using Promotion.Data.Entities;
using Promotion.Service;
using Promotion.Service.IService;
using System.Collections.Generic;

namespace Tests
{
    public class MemoryProviderTests
    {
        public InMemoryProvider InMemoryProvider = new MemoryProvider();
        //public MemoryProviderTests(InMemoryProvider _InMemoryProvider)
        //{
        //    InMemoryProvider = _InMemoryProvider;
        //}

        [SetUp]
        public void Setup()
        {
        }

        [Test,Order(1)]
        public void Get_All_Products()
        {
            var results = InMemoryProvider.AllProducts();
            Assert.IsNotNull(results);
            Assert.IsInstanceOf<IEnumerable<Product>>(results);
        }

        [Test, Order(2)]
        public void Get_All_Discounts()
        {
            var results = InMemoryProvider.AllDiscounts();
            Assert.IsNotNull(results);
            Assert.IsInstanceOf<IEnumerable<Discount>>(results);
        }
    }
}