using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using Core.Utilities.Result;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {

            var context = new ValidationContext<Car>(car);
            CarValidator carValidator = new CarValidator();
            var result = carValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            _carDal.Add(car);
           
           
               return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {

            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);

        }
        [CacheAspect]//key,value
        public IDataResult<List<Car>>GetAll()
        {
            if (DateTime.Now.Hour >19|| DateTime.Now.Hour<20) // Saturday is weekend, throw error result
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        //içerisinde listofcarolan ve işlem döndüren demek

        public IDataResult< List<Car> >GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult< List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));

        }

        public IDataResult< List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));

        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));
        }


        public IDataResult< List<Car> >GetByModelYear(int year)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear == year)); // bu nasıl çalışıyor bilmiyorum //tamamdır bakayım ben az daha bu kadar oldu en azından :D
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        public IResult Update(Car car)
        {


            var context = new ValidationContext<Car>(car);
            CarValidator carValidator = new CarValidator();
            var result = carValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            _carDal.Update(car);

            return new SuccessResult(Messages.Updated);

               
                
            }
            
        }
    }

