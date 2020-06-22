using Promotion.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Service.IService
{
    public interface IRuleA
    {
        double CheckRuleA(Product product, List<Product> products, List<Discount> discounts);
    }
}
