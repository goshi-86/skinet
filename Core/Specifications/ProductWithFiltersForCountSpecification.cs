﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
 public   class ProductWithFiltersForCountSpecification: BaseSpecifications<Product>
    {
       public ProductWithFiltersForCountSpecification(ProductSpecParams productSpecParams )
            :base(x => 
                  (!productSpecParams.BrandId.HasValue || x.ProductBrandId==productSpecParams.BrandId) &&
                 (!productSpecParams.TypeId.HasValue || x.ProductTypeId ==productSpecParams.TypeId)
                  )
        {


        }
    }
}
