
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
  public  class Result:IResult
    {
        private bool message; //çck
        private string success;


        public Result (bool success,string message):this (success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; } //reodanly constructorde set ediliebilir süslüye ne yazarsan onu implemente eder

        public string Message { get; }
    }
}
