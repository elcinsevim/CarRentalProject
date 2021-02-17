﻿using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public  class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
    
        public IResult Add(Users users)
        {

            _userDal.Add(users);
            return new SuccessResult();
        }

        public IResult Delete(Users users)
        {
            _userDal.Delete(users);
            return new SuccessResult();
        }
        public IDataResult<List<Users>> GetAll()
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll());
        }
            public IDataResult<Users> GetById(int UserId)
        {
            return new SuccessDataResult<Users>(_userDal.Get(b => b.UserId == UserId));
        }

        public IResult Update(Users users)
        {
            _userDal.Update(users);
            return new SuccessResult();
        }
    }
}