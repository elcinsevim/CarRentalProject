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
    }
}
