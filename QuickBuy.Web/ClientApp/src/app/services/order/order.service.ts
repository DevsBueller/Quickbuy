import { Injectable, Inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Order } from "../../model/order";

@Injectable({
  providedIn:'root'
})
export class OrderService {
  private _baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }
  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }
  public buyProduct(order: Order): Observable<number> {
    return this.http.post<number>(this._baseUrl + "api/order", JSON.stringify(order), { headers: this.headers })
  }
}
