using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
   public class RentalManager : IRentalService
    {
        

        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rentals rentals)
        {
            {
                var result = _rentalDal.GetAll(r => r.CarId == rentals.CarId && r.ReturnDate == null);
                if (result.Count > 0)
                    return new ErrorResult(Messages.NotAdded);
                _rentalDal.Add(rentals);
                return new SuccessResult(Messages.Added);
            }

        }

        public IResult Delete(Rentals rentals)
        {

            _rentalDal.Delete(rentals);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll());
        }

        public IDataResult<Rentals> GetById(int id)
        {
            return new SuccessDataResult<Rentals>(_rentalDal.Get(r =>r.CarId  == id));
        }

        public IDataResult<List<CarDetailDto>> GetRentalDetails(Expression<Func<Rentals, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rentals rentals)
        {
            _rentalDal.Update(rentals);
            return new SuccessResult(Messages.Updated);
        }
    }
}
