using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Promotion.Data.Entities
{
    public class Discount
    {
        public int DiscountId { get; set; }
        [Required]
        public string DiscountRule { get; set; }
        [Required]
        public int MinQty { get; set; }
        [Required]
        public double DiscountPercentage { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}
