using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
   public class ProductsWithTypesAndBrandsSpecifications : BaseSpecifications<Product>
    {
        public ProductsWithTypesAndBrandsSpecifications(ProductSpecParams productSpecParams)
              : base(criteria => 
                    (!productSpecParams.BrandId.HasValue || criteria.ProductBrandId == productSpecParams.BrandId) &&
                    (!productSpecParams.TypeId.HasValue || criteria.ProductTypeId == productSpecParams.TypeId)
                    )
        {
         
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex -1),productSpecParams.PageSize);
            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            
            }

        }

        public ProductsWithTypesAndBrandsSpecifications(int id)
            :base(x=>x.Id ==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
