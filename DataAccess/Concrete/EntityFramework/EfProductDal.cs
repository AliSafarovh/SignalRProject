using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProductDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, SignalRContext>, IProductDal
    {
        public async Task AddRangAsync(List<Product> products)
        {
            using var context = new SignalRContext();
            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }

        public async Task<List<ResultProductWithcategoryDto>> GetAllProductsWithCategories()
        {
            var context = new SignalRContext();
            var result = await context.Products.Include(p => p.Category)
                    .Select(p => new ResultProductWithcategoryDto
                    {
                        CategoryName = p.Category.CategoryName,
                        Description = p.Description,
                        ImageUrl = p.ImageUrl,
                        ProductName = p.ProductName,
                        Price = p.Price,
                        ProductId = p.ProductId,
                        Status = p.Status
                    }).ToListAsync();
            return result;
        }

    }
}
