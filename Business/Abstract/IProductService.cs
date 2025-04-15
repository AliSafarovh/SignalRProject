using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        public Task<IDataResult<List<ResultProductWithcategoryDto>>> TGetProductwithCategory();
        //Task<IResult> AddRangeAsync(List<Product> products);

    }
}
