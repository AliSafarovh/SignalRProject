using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.AboutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task<IResult> AddAsync(About about)
        {
            await _aboutDal.AddAsync(about);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(About about)
        {
            await _aboutDal.DeleteAsync(about);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<List<About>>> GetAllAsync()
        {
            var values = await _aboutDal.GetAllAsync();
            return new SuccessDataResult<List<About>>(values,Messages.ProductListed);

        }

        public async Task<IDataResult<About>> GetByIdAsync(int id)
        {
            var value = await _aboutDal.GetAsync(a => a.AboutId == id);
            if (value == null)
            {
                return new ErrorDataResult<About>(Messages.ProductNameNotFound);
            }
            return new SuccessDataResult<About>(value);
        }

        public async Task<IResult> UpdateAsync(About about)
        {
            await _aboutDal.UpdateAsync(about);
            return new SuccessDataResult<About>(Messages.ProductUpdated);
        }
    }
}