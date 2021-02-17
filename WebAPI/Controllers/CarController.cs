﻿using Business.Abstract;
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
    public class CarController : ControllerBase


        
    {
        ICarService _carService;
       
    


    public CarController(ICarService carService)
    {
        _carService = carService;
    }
    [HttpGet("getall")]
    public IActionResult getall()
    {
        var result = _carService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
}

