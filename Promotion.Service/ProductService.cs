using Promotion.Data.Entities;
using Promotion.Service.Helper;
using Promotion.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promotion.Service
{
    public class ProductService : IProductService
    {
        InMemoryProvider _ctx = null;
        public Utility util = null;
        public ProductService(InMemoryProvider service)
        {
            _ctx = service;
            util = new Utility();
        }
        public double GetDiscountedPrice(Product product, List<Product> products =null, List<int> discounts=null)
        {
            try
            {
                List<Discount> Discount = new List<Discount>();
                if (discounts != null && discounts.Count > 0)
                {
                    discounts.ToList().ForEach(id => {
                        Discount.Add(_ctx.AllDiscounts().FirstOrDefault(x => x.DiscountId == id));
                    });
                }
                return util.CalculatePrice(product, products, Discount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return _ctx.AllProducts().Where(p => p.IsActive == true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Discount> GetDiscounts()
        {
            try
            {
                return _ctx.AllDiscounts().Where(p => p.IsActive == true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
