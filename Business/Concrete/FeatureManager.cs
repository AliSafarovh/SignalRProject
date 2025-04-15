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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;
        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public async Task<IResult> AddAsync(Feature Tentity)
        {
            await _featureDal.AddAsync(Tentity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(Feature Tentity)
        {
            await _featureDal.DeleteAsync(Tentity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<List<Feature>>> GetAllAsync()
        {
            var values = await _featureDal.GetAllAsync();
            return new SuccessDataResult<List<Feature>>(values, Messages.ProductListed);
        }

        public async Task<IDataResult<Feature>> GetByIdAsync(int id)
        {
            var value = await _featureDal.GetAsync(f => f.FeatureId == id);
            if (value== null)
            {
                return new ErrorDataResult<Feature>(Messages.ProductNameNotFound);

            }
            return new SuccessDataResult<Feature>(value, Messages.ProductListed);
        }

        public async Task<IResult> UpdateAsync(Feature Tentity)
        {
            await _featureDal.UpdateAsync(Tentity);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
