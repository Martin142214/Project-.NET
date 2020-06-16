using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {

        private IProductRepository _productRepository;
        private AppDbContext context;

        public ProductsController(IProductRepository productRepository, AppDbContext context)

        {
            _productRepository = productRepository;
            this.context = context;
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

        [HttpGet, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {

            _productRepository.Delete(id);

            return RedirectToAction("Products");
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
        [Authorize(Roles = "Admin, User")]
        public IActionResult BuyProduct(int id)
        {
            var product = context.Products.Find(id);
            if (product.Quantity != 0)
            {
                product.Quantity--;
                return RedirectToAction("productDetails", id);
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

            Products product = new Products();
            if (ModelState.IsValid)
            {
                if (model.Photo != null)
                {
                    ImageUploadServices services = new ImageUploadServices();
                    string fileName = services.UploadImage(model);
                    product.Photo = fileName;
                }
                product.ProductName = model.ProductName;
                product.Price = model.Price;



                Products newProduct = _productRepository.Add(product);
                return RedirectToAction("Products", new { id = newProduct.Id });
            }

            return View();
        }



        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(int id)
        {
            _productRepository.Delete(id);

            return RedirectToAction("products");
        }


    }
}
