using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{

    public interface IDataResult<T> : IResult//true ve false ilave t türünde data olacak
     {  //datada burada arabalarımız
        //success ve messageye ilave bu
      T Data { get; }
        //hem mesajı hemde dondureceği seyi ,hemde datayı içeren
    }
}
