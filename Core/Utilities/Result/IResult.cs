using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
  public  interface IResult
    { //temelvoidleriçinbaşlangıççç??
        bool Success { get; }  //getter demek reutrn demek
        string Message { get; }

    }
}
