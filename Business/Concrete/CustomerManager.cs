using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class CustomerManager : ICustomerService
    {

        ICustomerDal _customerDal;
        public CustomerManager (ICustomerDal customerDal)
        {
            _customerDal= customerDal;
        }

        public IResult Add(Customers customer)


        {

            var context = new ValidationContext<Customers>(customer);
            CustomerValidator colorValidator = new CustomerValidator();
            var result = colorValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customers customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll());
        }

        public IDataResult<Customers> GetById(int id)
        {
            return new SuccessDataResult<Customers>(_customerDal.Get(c => c.UserId == id));
        }

        public IResult Update(Customers customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
