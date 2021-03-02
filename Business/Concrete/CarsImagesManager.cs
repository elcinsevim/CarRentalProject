using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Helpers;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarsImagesManager :ICarsImagesService

    {
        ICarImagesDal _carImagesDal;
        public CarsImagesManager(ICarImagesDal carImageDal)
        {
            _carImagesDal = carImageDal;
        }

        [ValidationAspect(typeof(CarsImagesValidator))]
        public IResult Add(IFormFile file, CarImages carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelpers.Add(file);
            carImage.CreationDate = DateTime.Now;
            _carImagesDal.Add(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarsImagesValidator))]
        public IResult Delete(CarImages carImages)
        {
            FileHelpers.Delete(carImages.ImagePath);
            _carImagesDal.Delete(carImages);
            return new SuccessResult();
        }

       
        [ValidationAspect(typeof(CarsImagesValidator))]
        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(c => c.ImagesId == id));
        }

        [ValidationAspect(typeof(CarsImagesValidator))]
        public IDataResult<List<CarImages>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(c => c.CarId == carId));
        }

        [ValidationAspect(typeof(CarsImagesValidator))]
        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var carImagecount = _carImagesDal.GetAll(p => p.CarId == carId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        private List<CarImages> CheckIfAnyCarImageExists(int carId)
        {
            string path = Environment.CurrentDirectory + @"\images\DefaultCar.jpg";
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Any();

            if (result)
            {
                return _carImagesDal.GetAll(p => p.CarId == carId);
            }

            return new List<CarImages> { new CarImages { CarId = carId, ImagePath = path, CreationDate = DateTime.Now } };
        }

        IDataResult<List<CarImages>> ICarsImagesService.GetAll()
        {
            throw new NotImplementedException();
        }

        IDataResult<CarImages> ICarsImagesService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<CarImages>> ICarsImagesService.GetByCarId(int id)
        {
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(CarsImagesValidator))]
        public IResult Update(IFormFile file, CarImages carImage)
        {
                     
            {
                carImage.ImagePath = FileHelpers.Update(_carsImagesDal.Get(c => c.ImagesId == carImage.ImagesId).ImagePath, file);
                carImage.CreationDate = DateTime.Now;
                _carImagesDal.Update(carImage);
                return new SuccessResult();
            }

        }
    }
}