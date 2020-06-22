using Promotion.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promotion.Service.IService
{
    public interface InMemoryProvider
    {
        IQueryable<Product> AllProducts();
        IQueryable<Discount> AllDiscounts();
    }
}
