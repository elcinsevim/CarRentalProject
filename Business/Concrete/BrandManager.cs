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
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)                                            
        {
            var context = new ValidationContext<Brand>(brand);
            BrandValidator brandValidator = new BrandValidator();
            var result = brandValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            _brandDal.Add(brand);
          
            {
                return new SuccessResult(Messages.Added);
            }

            }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);

        }
        



        public IDataResult<List<Brand> >GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Brand>  GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {

                return new ErrorResult(Messages.NotUpdated);
            }

            _brandDal.Update(brand);
           
            {
                return new SuccessResult(Messages.Updated);
            }
        
        }
    }
}