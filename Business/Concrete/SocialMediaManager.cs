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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;
        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public async Task<IResult> AddAsync(SocialMedia Tentity)
        {
            await _socialMediaDal.AddAsync(Tentity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(SocialMedia Tentity)
        {
            await _socialMediaDal.DeleteAsync(Tentity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<List<SocialMedia>>> GetAllAsync()
        {
            var values = await _socialMediaDal.GetAllAsync();
            return new SuccessDataResult<List<SocialMedia>>(values, Messages.ProductListed);
        }

        public async Task<IDataResult<SocialMedia>> GetByIdAsync(int id)
        {
            var value = await _socialMediaDal.GetAsync(s => s.SocialMediaId == id);
            if (value == null)
            {
                return new ErrorDataResult<SocialMedia>(Messages.ProductNameNotFound);
            }
            return new SuccessDataResult<SocialMedia>(value);
        }

        public async Task<IResult> UpdateAsync(SocialMedia Tentity)
        {
            await _socialMediaDal.UpdateAsync(Tentity);
            return new SuccessDataResult<SocialMedia>(Messages.ProductUpdated);
        }
    }
}
