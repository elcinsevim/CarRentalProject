﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car { BrandId = 1, ColorId = 1, DailyPrice = 300000, Description = "BMW", Id = 1, ModelYear = "2014" },
                new Car { BrandId = 2, ColorId = 2, DailyPrice = 20000, Description = "AUDI", Id = 2, ModelYear = "2019" },
                new Car { BrandId = 3, ColorId = 3, DailyPrice = 400000, Description = "MERCEDES", Id = 3, ModelYear = "2011" },
                new Car { BrandId = 4, ColorId = 4, DailyPrice = 50000, Description = "ASTON MARTİN", Id = 4, ModelYear = "2019" },
                new Car { BrandId = 5, ColorId = 5, DailyPrice = 100000, Description = "VOLVO", Id = 5, ModelYear ="2018" }
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(b => b.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }
        public List<Car>GetAllByCategory (int brandId)
        {
            return _car.Where(b => b.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(b => b.ColorId == car.ColorId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.Id = car.Id;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}

       