﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
       Task <List<ResultProductWithcategoryDto>> GetAllProductsWithCategories();
        Task AddRangAsync(List<Product> products);
    }
}
