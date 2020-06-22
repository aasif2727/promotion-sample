using Promotion.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Service.IService
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Discount> GetDiscounts();
        double GetDiscountedPrice(Product product, List<Product> products, List<int> discounts);
    }
}
