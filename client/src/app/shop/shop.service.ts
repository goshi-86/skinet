import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IPagination } from '../shared/models/paginations';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/productType';
import {delay, map} from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ShopService {
baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) { }
  getProducts(brandId?: number, typeId?: number, sort?: string)
  {
    let params = new HttpParams();

     // tslint:disable-next-line: align
     if (brandId)
     {
      params = params.append('brandId', brandId.toString() );
      }

    if (typeId)
    {
      params = params.append('typeId', typeId.toString() );
    }
    params = params.append('sort', sort);
    params = params.append('pagesize', '50' );

    return this.http.get<IPagination>(this.baseUrl + 'products', {observe: 'response', params})
    .pipe(
      map(response => {
         return response.body;
      })
    );
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
