import {Injectable} from '@angular/core';
import {Observable, Subject} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {environment as env} from '../../environments/environment';

export type Cart = { [k: string]: number };

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private readonly _cart = new Subject<Cart>();

  constructor(private http: HttpClient) {
  }

  get cart$(): Observable<Cart> {
    return this._cart.asObservable();
  }

  fetchCart() {
    this.http.get<Cart>(`${env.apiUrl}/customer/cart`, {withCredentials: true})
      .subscribe(it => this._cart.next(it));
  }

  addToCart(id: string) {
    this.http.post<Cart>(`${env.apiUrl}/customer/cart/${id}`, null, {withCredentials: true})
      .subscribe(it => this._cart.next(it));
  }

  removeFromCart(id: string) {
    this.http.delete<Cart>(`${env.apiUrl}/customer/cart/${id}`, {withCredentials: true})
      .subscribe(it => this._cart.next(it));
  }
}
