using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByBrandId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByColorId(int id)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int ıd)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}

