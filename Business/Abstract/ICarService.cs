using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
      List<Car> GetAll();
      
        List<Car> GetCarsByColorId(int id);
        List<Car> GetCarsByBrandId(int id);
       

        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
