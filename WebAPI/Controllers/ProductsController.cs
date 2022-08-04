using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Business.Concrete;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled --dependent only abstract
        //IoC Container --Inversion of Control.
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
     public IActionResult GetAll(){
        var result = _productService.GetAll();
        if(result.Success){
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
     
    }
    
        [HttpPost("add")]
     public IActionResult Add(Product product){
         var result =_productService.Add(product);
           if(result.Success){
            return Ok(result);
        }
        return BadRequest(result);
     }

   [HttpGet("getbyid")]
     public IActionResult GetById(int id){
        var result = _productService.GetById(id);
        if(result.Success){
            return Ok(result);
        }
        return BadRequest(result.Message);
     
    }
    

    }

}