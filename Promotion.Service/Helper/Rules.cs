using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Promotion.Data.Entities;
using Promotion.Service.IService;

namespace Promotion.Service.Helper
{
    public class Rules : IRuleA, IRuleB, IRuleCD, INoRule
    {
        public double CheckRuleA(Product product, List<Product> products, List<Discount> discounts)
        {
            if (discounts.Count > 0)
            {
                var rule = discounts.FirstOrDefault(p => p.DiscountRule.Equals("A") && p.IsActive == true);
                if (rule != null)
                {
                    int temp = product.Qty / rule.MinQty;
                    int rem = product.Qty % rule.MinQty;
                    return (Math.Round((temp * rule.MinQty * product.UnitPrice) - (temp * rule.MinQty * product.UnitPrice * rule.DiscountPercentage) / 100)) + (rem * product.UnitPrice);
                }
                else
                {
                    return product.UnitPrice * product.Qty;
                }
            }
            else
            {
                return product.UnitPrice * product.Qty;
            }
        }

        public double CheckRuleB(Product product, List<Product> products, List<Discount> discounts)
        {
            if (discounts.Count > 0)
            {
                var rule = discounts.FirstOrDefault(p => p.DiscountRule.Equals("B") && p.IsActive == true);
                if (rule != null)
                {
                    int temp = product.Qty / rule.MinQty;
                    int rem = product.Qty % rule.MinQty;
                    return (Math.Round((temp * rule.MinQty * product.UnitPrice) - (temp * rule.MinQty * product.UnitPrice * rule.DiscountPercentage) / 100)) + (rem * product.UnitPrice);
                }
                else
                {
                    return product.UnitPrice * product.Qty;
                }
            }
            else
            {
                return product.UnitPrice * product.Qty;
            }
        }

        public double CheckRuleCD(Product product, List<Product> products, List<Discount> discounts)
        {
            if (discounts.Count > 0)
            {
                var rule = discounts.FirstOrDefault(p => p.DiscountRule.Equals("C+D") && p.IsActive == true);
                int DQty = products.Where(p => p.Title.Equals("D") && p.IsActive == true).Count();
                if (rule != null && DQty > 0)
                {
                    if (product.Qty > DQty)
                    {
                        return Math.Round(((DQty * product.UnitPrice) - ((DQty * product.UnitPrice * rule.DiscountPercentage) / 100)) + ((product.Qty - DQty) * product.UnitPrice));
                    }
                    else if (product.Qty < DQty)
                    {
                        return Math.Round(((product.Qty * product.UnitPrice) - ((product.Qty * product.UnitPrice * rule.DiscountPercentage) / 100)) + ((DQty - product.Qty) * product.UnitPrice));
                    }
                    else
                    {
                        return Math.Round((DQty * product.UnitPrice) - ((DQty * product.UnitPrice * rule.DiscountPercentage) / 100));
                    }
                }
                else
                {
                    return product.UnitPrice * product.Qty;
                }
            }
            else
            {
                return product.UnitPrice * product.Qty;
            }
        }

        public double NoRule(Product product)
        {
            return product.UnitPrice * product.Qty;
        }
    }
}
