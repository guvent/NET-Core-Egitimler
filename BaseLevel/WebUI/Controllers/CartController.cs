using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Helpers;
using WebUI.Models;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class CartController:Controller
    {
        private ICartService _cardService;
        private ICartSessionHelper _cartSessionHelper;
        private IProductService _productService;

        public CartController(ICartService cardService, ICartSessionHelper cartSessionHelper, IProductService productService)
        {
            _cardService = cardService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var model = new CartListViewModel
            {
                Cart = _cartSessionHelper.GetCart("cart")
            };

            return View(model);
        }

        public IActionResult AddToCart(int productId)
        {
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart("cart");

            _cardService.AddToCart(cart,product);

            _cartSessionHelper.SetCart("cart", cart);

            string redirectUrl = "/Product?categoryId="+product.CategoryID.ToString();

            TempData.Add("message", product.ProductName +" sepete eklendi!");

            //return RedirectToAction("Index", "Product","?categoryId="+product.CategoryID.ToString());

            return Redirect(redirectUrl);

        }

        public IActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart("cart");

            _cardService.RemoveFromCart(cart,productId);

            _cartSessionHelper.SetCart("cart",cart);

            TempData.Add("message", product.ProductName + " sepetten çıkartıldı!");

            return RedirectToAction("Index", "Cart");

        }

        public IActionResult Complete()
        {
            var model = new ShippingDetailsViewModel
            {
                ShippingDetail = new ShippingDetail()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            TempData.Add("message", "Siparişiniz alındı!");
            _cartSessionHelper.Clear();
            return RedirectToAction("Index", "Product");
        }
    }

}
