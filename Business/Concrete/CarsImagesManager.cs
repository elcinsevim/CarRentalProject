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
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarsImagesManager : ICarsImagesService

    {
        ICarsImagesDal _carImagesDal;
        public CarsImagesManager(ICarsImagesDal carsImagesDal)
        {
            _carImagesDal = carsImagesDal;
        }
      
        public IResult Add(IFormFile file, CarImage carImage)
        {

            IResult result = BusinessRules.Run(CarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelpers.Add(file);
                carImage.CreationDate = DateTime.Now;
                _carImagesDal.Add(carImage);
                return new SuccessResult(Messages.AddadCarImage);
            

           
        }


        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImagesDal.Get(I => I.ImagesId== carImage.ImagesId).ImagePath;

            var result = BusinessRules.Run(FileHelpers.Delete(oldpath));

            if (result != null)
            {
                return result;
            }

            _carImagesDal.Delete(carImage);
            return new SuccessResult(Messages.DeleteCarImage);


        }



    
    [ValidationAspect(typeof(CarsImagesValidator))]
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(p => p.ImagesId== id));
        }
       

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll());
        }
        [ValidationAspect(typeof(CarsImagesValidator))]
        public IDataResult<CarImage> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(c=>c.ImagesId==id));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }
        private IResult CarImageLimitExceeded(int carid)
        {
            var carImagecount = _carImagesDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string ImagePath = @"\Images\logo.jpg";
            var result = _carImagesDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = ImagePath, CreationDate = DateTime.Now } };
            }
            return _carImagesDal.GetAll(p => p.CarId == id);
        }

    }
}

    
        