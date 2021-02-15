using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public interface IDataResult2<T>
    {
        T Data { get; }
    }

    public interface IDataResult3<T>
    {
        T Data { get; }
    }

    public interface IDataResult<T> : IResult
    {
        //success ve messageye ilave bu
        T Data { get; }
    }
}
