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
            return await _productRepository.GetProductsAsync();
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductTypeAsync()
        {
            var types = await _productRepository.GetProductTypeAsync();
            return Ok(types);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<Product>>> GetProductBrandAsync()
        {
            var productBands = await _productRepository.GetProductBrandAsync();
            return Ok(productBands);

        }

    }


}