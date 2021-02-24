using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
  public  class CarDetailDto:IDto
    {
        //
        
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
