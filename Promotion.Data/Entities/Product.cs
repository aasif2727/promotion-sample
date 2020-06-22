using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Promotion.Data.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public double UnitPrice { get; set; } = 0;
        [Required]
        public int Qty { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}
