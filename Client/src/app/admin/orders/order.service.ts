import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Order} from './order';
import {environment as env} from '../../../environments/environment';

@Injectable()
export class OrderService {

  constructor(private http: HttpClient) {
  }

  getAllOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(`${env.apiUrl}/admin/Orders`);
  }

  getOrderDetails(id: string): Observable<Order> {
    return this.http.get<Order>(`${env.apiUrl}/admin/Orders/${id}`);
  }
}
