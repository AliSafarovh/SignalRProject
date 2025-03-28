using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;
        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public async Task<IResult> AddAsync(Discount Tentity)
        {
            await _discountDal.AddAsync(Tentity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(Discount Tentity)
        {
            await _discountDal.DeleteAsync(Tentity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<List<Discount>>> GetAllAsync()
        {
            var values = await _discountDal.GetAllAsync();
            return new SuccessDataResult<List<Discount>>(values, Messages.ProductListed);
        }

        public async Task<IDataResult<Discount>> GetByIdAsync(int id)
        {
            var value = await _discountDal.GetAsync(d => d.DiscountId == id);
            if (value == null)
            {
                return new ErrorDataResult<Discount>(Messages.ProductNameNotFound);
            }
            return new SuccessDataResult<Discount>(value);
        }

        public async Task<IResult> UpdateAsync(Discount Tentity)
        {
            await _discountDal.UpdateAsync(Tentity);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
