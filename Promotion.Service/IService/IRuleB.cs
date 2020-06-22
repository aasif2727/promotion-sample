using Promotion.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Service.IService
{
    public interface IRuleB
    {
        double CheckRuleB(Product product, List<Product> products, List<Discount> discounts);
    }
}
