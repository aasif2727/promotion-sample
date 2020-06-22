using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Promotion.Data.Entities;
using Promotion.Service.IService;
using Promotion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Promotion.UI.Controllers
{
    public class HomeController : Controller
    {
        public IProductService _productService = null;
        ILogger<HomeController> _logger = null;
        public HomeController(IProductService productService, ILogger<HomeController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                ProductVM productList = new ProductVM();
                productList.products = _productService.GetProducts().ToList();
                productList.discounts = _productService.GetDiscounts().ToList();
                return View(productList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
                return null;
            }
        }

        [HttpGet]
        public IActionResult Load(string rules, string productObj)
        {
            try
            {
                List<CartSummary> cartSummary = new List<CartSummary>();
                List<int> ids = JsonConvert.DeserializeObject<List<int>>(rules);
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productObj);
                foreach (Product product in products)
                {
                    CartSummary cart = new CartSummary();
                    cart.ProductId = product.ProductId;
                    cart.Title = product.Title;
                    cart.Qty = product.Qty;
                    cart.TotalPrice = product.Qty * product.UnitPrice;
                    cart.DiscountedPrice = _productService.GetDiscountedPrice(product, products, ids.Count > 0? ids : null);
                    cartSummary.Add(cart);
                }
                ProductVM productList = new ProductVM();
                productList.CartSummary = cartSummary;
                return PartialView("_CartSummary", productList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
                return null;
            }
        }
    }
}
