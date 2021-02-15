using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        //void yerine ıresult diyeceğiz..
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
         IDataResult< List<Car> >GetAll();
        IDataResult<Car> GetById(int id);
       IDataResult<  List<Car>> GetAllByColorId(int id);
       IDataResult<   List<Car> >GetAllByBrandId(int id);
       IDataResult< List<Car>> GetByDailyPrice(decimal min, decimal max);
      IDataResult<  List<Car> >GetByModelYear(string year);
      IDataResult<  List<CarDetailDto> >GetCarDetails();

    }
}