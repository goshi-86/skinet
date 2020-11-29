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

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getProductTypes();
  }

  getProducts()
  {
    this.shopService.getProducts().subscribe(response => {
      this.products = response;
    }, error => {
      console.log(error);
    });
  }

  getBrands()
  {
    this.shopService.getBrands().subscribe(response => {
      this.brands = response;
    }, error => {
      console.log(error);
    });
  }

  getProductTypes()
  {
    this.shopService.getProductTypes().subscribe(response => {
      this.productTypes = response;
    }, error => {
      console.log(error);
    });
  }


}
