import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IPagination } from '../shared/models/paginations';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/productType';
import {delay, map} from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
@Injectable({
  providedIn: 'root'
})
export class ShopService {
baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) { }
  getProducts( shopParams:ShopParams)
  {
    let params = new HttpParams();

     // tslint:disable-next-line: align
     if (shopParams.brandId!=0)
     {
      params = params.append('brandId', shopParams.brandId.toString() );
      }

    if (shopParams.typeId!=0)
    {
      params = params.append('typeId', shopParams.typeId.toString() );
    }
   
    params = params.append('sort', shopParams.sort);
    params = params.append('pageSize', shopParams.pageSize.toString() );
    params = params.append('pageIndex',shopParams.pageNumber.toString());

    if (shopParams.search)
    {
      params = params.append('search', shopParams.search );
    }

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
