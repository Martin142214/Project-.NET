using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {

        private IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository, AppDbContext context)

        {
            _productRepository = productRepository;
        }

        public IActionResult Products(string searchString)
        {

            var product = _productRepository.GetAllProducts();

            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(p => p.ProductName.Contains(searchString));
            }

            return View(product);
        }

        public IActionResult Find(string searchString)
        {

            var products = from p in _productRepository.GetAllProducts()
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ProductName.Contains(searchString));
            }
            return View(products);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Products product = _productRepository.GetProduct(id);
            ProductCreateViewModel productEditViewModel = new ProductEditViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
            };

            return View(productEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {

                Products newProduct = new Products
                {
                    Id = model.Id,
                    ProductName = model.ProductName,
                    Price = model.Price,
                };

                _productRepository.Edit(newProduct);
                return RedirectToAction("Products", "buyandsell");
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _productRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }


        public ViewResult ProductDetails(int id)
        {

            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel()
            {
                Product = _productRepository.GetProduct(id),
                PageTitle = "Product details"
            };

            return View(productDetailsViewModel);
        }
        [HttpPost]
        public IActionResult BuyProduct(Products products)
        {
            if (ModelState.IsValid)
            {
                products.Quantity--;
            }
            return View();
        }

        [HttpGet]

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Products product = new Products
                {
                    ProductName = model.ProductName,
                    Price = model.Price,
                };
                Products newProduct = _productRepository.Add(product);
                return RedirectToAction("Products", new { id = newProduct.Id });
            }

            return View();


        }
    }
}