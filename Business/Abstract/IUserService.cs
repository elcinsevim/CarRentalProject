﻿using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService
    {
        IResult Add(Users users);
        IResult Delete(Users user);
        IResult Update(Users user);
        IDataResult<List<Users>> GetAll();
        IDataResult<Users> GetById(int id);
    }
}