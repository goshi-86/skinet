﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
 public   class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        public int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value>MaxPageSize?MaxPageSize:value);
        }

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }
        public string Search { get; set; }
    }
}
