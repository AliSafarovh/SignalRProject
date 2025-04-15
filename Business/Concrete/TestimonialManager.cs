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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task<IResult> AddAsync(Testimonial Tentity)
        {
            await _testimonialDal.AddAsync(Tentity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(Testimonial Tentity)
        {
            await _testimonialDal.DeleteAsync(Tentity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<List<Testimonial>>> GetAllAsync()
        {
            var values = await _testimonialDal.GetAllAsync();
            return new SuccessDataResult<List<Testimonial>>(values, Messages.ProductListed);
        }

        public async Task<IDataResult<Testimonial>> GetByIdAsync(int id)
        {
            var value = await _testimonialDal.GetAsync(t => t.TestimonialId == id);
            if (value == null)
            {
                return new ErrorDataResult<Testimonial>(Messages.ProductNameNotFound);
            }
            return new SuccessDataResult<Testimonial>(value);
        }

        public async Task<IResult> UpdateAsync(Testimonial Tentity)
        {
            await _testimonialDal.UpdateAsync(Tentity);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
