using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        public Task<IDataResult<List<GetCategoryWithProductsDto>>> TGetCategoryWithProducts(int id);
    }
}
