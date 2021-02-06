using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        { 
        if (brand.Name.Length > 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("new brand is added to the system");
            }
            else
            {
                Console.WriteLine("The new brand could not be added to the system, it does not meet the criteria.");
            }
            
            
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
           
        }
        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

       

        public void Update(Brand brand)
        {
            if (brand.Name.Length > 2)
            {
                _brandDal.Update(brand);
                Console.WriteLine("Marka sistemde basariyla guncellendi.");
            }
            else
            {
                Console.WriteLine("Lutfen marka ismini en az iki karakter olacak sekilde giriniz.");
            }

        }
    }
}
