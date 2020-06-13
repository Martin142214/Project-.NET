using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        public SQLProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Products> GetAllProducts()
        {
            return context.Products;
        }

        public Products GetProduct(int id)
        {
            return context.Products.Find(id);
        }

        public Products Add(Products product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public Products Delete(int id)
        {
            Products product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public Products Edit(Products productChanges)
        {
            var product = context.Products.Attach(productChanges);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return productChanges;
        }

    }
}
