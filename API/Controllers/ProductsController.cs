using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using System.Linq.Expressions;
using API.Dtos;
using AutoMapper;
using API.Errors;
using Microsoft.AspNetCore.Http;
using API.Helpers;

namespace API.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly IGenericRepository<ProductType> _typeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product>productRepo,IGenericRepository<ProductBrand> productBrand,IGenericRepository<ProductType> typeRepo,IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrand = productBrand;
            _typeRepo = typeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>> > GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
         
            var spec = new ProductsWithTypesAndBrandsSpecifications(productSpecParams);
            var products =  await _productRepo.ListAsync(spec);
            var countSpec = new ProductWithFiltersForCountSpecification(productSpecParams);
            var count = await _productRepo.CountAsync(countSpec);
            var data=_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productSpecParams.PageIndex, productSpecParams.PageSize, count,data));



            //return products.Select(products => new ProductToReturnDto
            //{
              //  Id = products.Id,
                //Name = products.Name,
               // Description = products.Description,
                //PictureUrl = products.PictureUrl,
               // Price = products.Price,
               // ProductBrand = products.ProductBrand.Name,
              //  ProductType = products.ProductType.Name
            //}

            //).ToList();
               
          
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            //List<Expression<Func<Product, object>>> Includes = new List<Expression<Func<Product, object>>>(); ;
           // Expression<Func<Product, bool>> Criteria;

           // Includes.Add(x => x.ProductBrand);
           // Includes.Add(x => x.ProductType);
           // Criteria = (x => x.ProductTypeId == id);
           
            var spec = new ProductsWithTypesAndBrandsSpecifications(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if (product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductToReturnDto>(product);

           
        
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductTypeAsync()
        {
            var types = await _typeRepo.ListAllAsync();
            return Ok(types);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<Product>>> GetProductBrandAsync()
        {
            var productBands = await _productBrand.ListAllAsync();
            return Ok(productBands);

        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)

        {
            return Ok();
        }

    }


}