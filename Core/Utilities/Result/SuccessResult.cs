using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)//mesaj vermek isterse
        {
            //üst altıda karsılar
        }
        public SuccessResult() : base(true)//mesaj vermek istemiyorsa
        {

        }
    }
}