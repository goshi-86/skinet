import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProduct[];
  brands: IBrand[];
  productTypes: IProductType[];
  barndIdSelected: number;
  productIdSelected: number;
  totalItems: number;
  sortSelected = 'name';
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}
  ];
  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getProductTypes();
  }

  getProducts()
  {
    this.shopService.getProducts(this.barndIdSelected, this.productIdSelected).subscribe(response => {
      this.products = response.data;
      this.totalItems = response.count;
    }, error => {
      console.log(error);
    });
  }

  getBrands()
  {
    this.shopService.getBrands().subscribe(response => {
      this.brands = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  getProductTypes()
  {
    this.shopService.getProductTypes().subscribe(response => {
      this.productTypes = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  onBrandSelected(brandId: number)
  {
    this.barndIdSelected = brandId;
    this.onSortSelected('priceDesc');
  }
  onTypeSelected(typeId: number)
  {
    this.productIdSelected = typeId;
    this.getProducts();
  }

  onSortSelected(sort: string)
  {
    this.sortSelected = sort;
    this.getProducts();
  }
}
