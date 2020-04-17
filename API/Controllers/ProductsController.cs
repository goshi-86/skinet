using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
       
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>> > GetProducts()
        {
            var product = await _productRepository.GetProductsAsync();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

    }


}