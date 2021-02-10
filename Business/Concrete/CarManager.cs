using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba sisteme eklendi");
            }
            else
            {
                Console.WriteLine("günlük limit 0 dan büyük olmalıdır.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba sistemden silindi");

        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);

        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);

        }

        public Car GetById(int id)
        {
            throw new NotImplementedException();
        }


        public List<Car> GetByModelYear(int year)
        {
            return _carDal.GetAll(c => c.ModelYear==year);
        }

        public List<Car> GetByModelYear(string year)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine("Araba bilgisi sistemde güncellendi");
            }
            else
            {
                Console.WriteLine("günlük limit 0 dan büyük olmalı");
            }
        }
    }
}
