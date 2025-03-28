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
    public class FeatureDescriptionManager : IFeatureDescriptionService
    {
        private readonly IFeatureDescriptionDal _featureDescriptionDal;
        public FeatureDescriptionManager(IFeatureDescriptionDal featureDescripitionDal)
        {
            _featureDescriptionDal = featureDescripitionDal;
        }

        public async Task<IResult> AddAsync(FeatureDescripition Tentity)
        {
            await _featureDescriptionDal.AddAsync(Tentity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(FeatureDescripition Tentity)
        {
            await _featureDescriptionDal.DeleteAsync(Tentity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<List<FeatureDescripition>>> GetAllAsync()
        {
            var values = await _featureDescriptionDal.GetAllAsync();
            return new SuccessDataResult<List<FeatureDescripition>>(values, Messages.ProductListed);
        }

        public async Task<IDataResult<FeatureDescripition>> GetByIdAsync(int id)
        {
            var result = _featureDescriptionDal.GetAsync(f => f.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<FeatureDescripition>(Messages.ProductNameNotFound);
            }
            return new SuccessDataResult<FeatureDescripition>();
        }

        public Task<IResult> UpdateAsync(FeatureDescripition Tentity)
        {
            throw new NotImplementedException();
        }
    }
}
