using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
   public class ProductsWithTypesAndBrandsSpecifications : BaseSpecifications<Product>
    {
        public ProductsWithTypesAndBrandsSpecifications()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

        public ProductsWithTypesAndBrandsSpecifications(int id)
            :base(x=>x.Id ==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
