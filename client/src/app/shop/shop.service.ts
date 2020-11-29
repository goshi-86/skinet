import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/productType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) { }
  getProducts()
  {
    let params = new HttpParams();
    params = params.append('brandId', '' );
    return this.http.get<IProduct[]>(this.baseUrl + 'products', {observe: 'reponse', params});
  }

  getBrands()
  {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getProductTypes()
  {
    return this.http.get<IProductType[]>(this.baseUrl + 'products/types');
  }
}
