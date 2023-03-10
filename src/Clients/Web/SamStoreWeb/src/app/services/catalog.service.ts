import { HttpClient } from "@angular/common/http";
import { ProductDTO } from "./../models/Products/product.DTO";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { BaseApiService } from "./abstractions/base.service";

@Injectable({
  providedIn: "root",
})
export class CatalogService extends BaseApiService {
  constructor(private _httpClient: HttpClient) {
    super("catalog", "Catalog");
  }

  getAllProducts(): Observable<Array<ProductDTO>> {
    return this._httpClient.get<Array<ProductDTO>>(`${this._baseURL}/products`);
  }
}
