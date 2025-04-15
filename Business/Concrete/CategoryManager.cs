using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IResult> AddAsync(Category entity)
        {
            await _categoryDal.AddAsync(entity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(Category entity)
        {
            await _categoryDal.DeleteAsync(entity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<List<Category>>> GetAllAsync()
        {
            var values = await _categoryDal.GetAllAsync();
            return new SuccessDataResult<List<Category>>(values, Messages.ProductListed);
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            var value = await _categoryDal.GetAsync(c => c.CategoryId == id);
            if (value == null)
            {
                return new ErrorDataResult<Category>(Messages.ProductNameNotFound);
            }
            return new SuccessDataResult<Category>(value);
        }

        public async Task<IDataResult<List<GetCategoryWithProductsDto>>> TGetCategoryWithProducts(int id)
        {

           var value = await _categoryDal.GetByIdCategoryWithProducts(id);
            return new SuccessDataResult<List<GetCategoryWithProductsDto>>(value);
        }

        public async Task<IResult> UpdateAsync(Category entity)
        {
            await _categoryDal.UpdateAsync(entity);
            return new SuccessDataResult<Category>(Messages.ProductUpdated);
        }
    }
}
