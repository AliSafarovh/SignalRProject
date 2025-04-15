using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CategoryDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, SignalRContext>, ICategoryDal
    {
        public async Task<List<GetCategoryWithProductsDto>> GetByIdCategoryWithProducts(int categoryId)
        {
            var context = new SignalRContext();

            // Verilən categoryId-ə görə kategoriya və əlaqəli məhsul adlarını çəkirik
            var result = await context.Categories
                .Where(c => c.CategoryId == categoryId)  // Verilən categoryId-yə uyğun kategoriyanı tapırıq
                .Include(c => c.Products)  // Məhsulları daxil edirik
                .Select(c => new GetCategoryWithProductsDto
                {
                    Name = c.CategoryName,  // Kategoriyanın adı
                    ProductNames = c.Products.Select(p => p.ProductName).ToList()  // Məhsul adlarının siyahısı
                })
                .ToListAsync();  // Nəticəni asinxron şəkildə siyahıya çeviririk

            return result;
        }
    }

}
