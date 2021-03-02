using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
   public class CarImages:IEntity
    {
        [Key]
        public int ImagesId { get; set; }
        public int CarId { get; set; }
        public int ImagePath { get; set; }
        public DateTime CreationDate { get; set; }


    }
}
