﻿using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
  public  class EfCarImagesDal : EfEntityRepositoryBase<Customers, CarRentalContext>, ICarsImagesDal
    {
        
    }
}
