using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImages : ControllerBase
    {
        ICarsImagesService _carsImagesService;

       

        public CarImages(ICarsImagesService  carsImagesService)
        {
            _carsImagesService = carsImagesService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carsImagesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carsImagesService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImages carImages)
        {
            var result = _carsImagesService.Add(file, carImages);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int id)
        {
            var carImage = _carsImagesService.GetById(id).Data;
            var result = _carsImagesService.Delete(carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}

