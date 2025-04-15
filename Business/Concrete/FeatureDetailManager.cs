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
    public class FeatureDetailManager : IFeatureDetailService
    {
        private readonly IFeatureDetailDal _featureDetailDal;
        public FeatureDetailManager(IFeatureDetailDal featureDetailDal)
        {
            _featureDetailDal = featureDetailDal;
        }

        public async Task<IResult> AddAsync(FeatureDetail Tentity)
        {
            await _featureDetailDal.AddAsync(Tentity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(FeatureDetail Tentity)
        {
            await _featureDetailDal.DeleteAsync(Tentity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<List<FeatureDetail>>> GetAllAsync()
        {
            var values = await _featureDetailDal.GetAllAsync();
            if (values == null)
            {
                return new ErrorDataResult<List<FeatureDetail>>(Messages.ProductNotFound);
            }
            return new SuccessDataResult<List<FeatureDetail>>(values, Messages.ProductListed);
        }

        public async Task<IDataResult<FeatureDetail>> GetByIdAsync(int id)
        {
            var value = await _featureDetailDal.GetAsync(f => f.FeatureDetailId == id);
            if (value == null)
            {
                return new ErrorDataResult<FeatureDetail>(Messages.ProductNameNotFound);
            }
            return new SuccessDataResult<FeatureDetail>(value);
        }

        public async Task<IResult> UpdateAsync(FeatureDetail Tentity)
        {
            await _featureDetailDal.UpdateAsync(Tentity);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
