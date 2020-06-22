using Promotion.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promotion.Service.Helper
{
    public class Utility
    {
        private Rules Rules { get; set; }
        public Utility()
        {
            Rules = new Rules();
        }
        public double CalculatePrice(Product product, List<Product> products, List<Discount> discounts)
        {
            if (product.Title.Equals("A") && product.Qty > 0)
            {
                return Rules.CheckRuleA(product, products, discounts);
            }
            else if (product.Title.Equals("B") && product.Qty > 0)
            {
                return Rules.CheckRuleB(product, products, discounts);
            }
            else if (product.Title.Equals("C") && product.Qty > 0)
            {
                return Rules.CheckRuleCD(product, products, discounts);
            }
            else if (product.Title.Equals("D") && product.Qty > 0)
            {
                var rule = discounts.FirstOrDefault(p => p.DiscountRule.Equals("C+D") && p.IsActive == true);
                int CQty = products.Where(p => p.Title.Equals("C") && p.IsActive == true).Count();
                if (rule != null && CQty > 0)
                {
                    if (product.Qty > CQty)
                    {
                        return Math.Round(((CQty * product.UnitPrice)-((CQty * product.UnitPrice * rule.DiscountPercentage) / 100)) + ((product.Qty - CQty) * product.UnitPrice));
                    }
                    else if (product.Qty < CQty)
                    {
                        return Math.Round(((product.Qty * product.UnitPrice)-((product.Qty * product.UnitPrice * rule.DiscountPercentage) / 100)) + ((CQty - product.Qty) * product.UnitPrice));
                    }
                    else
                    {
                        return Math.Round((CQty * product.UnitPrice)-((CQty * product.UnitPrice * rule.DiscountPercentage) / 100));
                    }
                }
                else
                {
                    return product.UnitPrice * product.Qty;
                }
            }
            else
            {
                return Rules.NoRule(product);
            }
        }
    }
}
