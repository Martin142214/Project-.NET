using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IProductRepository
    {
        Products GetProduct(int id);
        IEnumerable<Products> GetAllProducts();

        Products Add(Products product);

        Products Edit(Products productChanges);
        Products Delete(int id);
    }
}
