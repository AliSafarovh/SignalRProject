using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;
        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public async Task<IResult> AddAsync(Booking entity)
        {
            await _bookingDal.AddAsync(entity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(Booking entity)
        {
            await _bookingDal.DeleteAsync(entity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<List<Booking>>> GetAllAsync()
        {
            var values = await _bookingDal.GetAllAsync();
            return new SuccessDataResult<List<Booking>>(values, Messages.ProductListed);
        }

        public async Task<IDataResult<Booking>> GetByIdAsync(int id)
        {
            var value = await _bookingDal.GetAsync(b => b.BookingId == id);
            if (value == null)
            {
                return new ErrorDataResult<Booking>(Messages.ProductNameNotFound);
            }
            return new SuccessDataResult<Booking>(value);
        }

        public async Task<IResult> UpdateAsync(Booking entity)
        {
            await _bookingDal.UpdateAsync(entity);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}