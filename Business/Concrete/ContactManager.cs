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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task<IResult> AddAsync(Contact Tentity)
        {
            await _contactDal.AddAsync(Tentity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(Contact Tentity)
        {
            await _contactDal.DeleteAsync(Tentity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<List<Contact>>> GetAllAsync()
        {
            var values = await _contactDal.GetAllAsync();
            return new SuccessDataResult<List<Contact>>(values, Messages.ProductListed);
        }

        public async Task<IDataResult<Contact>> GetByIdAsync(int id)
        {
            var value = await _contactDal.GetAsync(c => c.ContactId == id);
            if (value == null)
            {
                return new ErrorDataResult<Contact>(Messages.ProductNameNotFound);
            }
            return new SuccessDataResult<Contact>(value);
        }

        public async Task<IResult> UpdateAsync(Contact Tentity)
        {
            await _contactDal.UpdateAsync(Tentity);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
