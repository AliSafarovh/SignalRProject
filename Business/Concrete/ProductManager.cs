using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<IResult> AddAsync(Product Tentity)
        {
            await _productDal.AddAsync(Tentity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> AddRangeAsync(List<Product> products)
        {
            await _productDal.AddRangAsync(products);
            return new SuccessDataResult<List<Product>>(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(Product Tentity)
        {
            await _productDal.DeleteAsync(Tentity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<List<Product>>> GetAllAsync()
        {
            var values = await _productDal.GetAllAsync();
            return new SuccessDataResult<List<Product>>(values, Messages.ProductListed);
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id)
        {
            var value = await _productDal.GetAsync(p => p.ProductId == id);
            if (value == null)
            {
                return new ErrorDataResult<Product>(Messages.ProductNameNotFound);
            }
            return new SuccessDataResult<Product>(value);
        }

        public async Task<IDataResult<List<ResultProductWithcategoryDto>>> TGetProductwithCategory()
        {
            var values = await _productDal.GetAllProductsWithCategories();
            return new SuccessDataResult<List<ResultProductWithcategoryDto>>(values);
        }

        public async Task<IResult> UpdateAsync(Product Tentity)
        {
            await _productDal.UpdateAsync(Tentity);
            return new SuccessResult(Messages.ProductUpdated);
        }


    }
}
