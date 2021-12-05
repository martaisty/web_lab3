import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, Resolve, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs';
import {OrderService} from './order.service';
import {Order} from './order';

@Injectable()
export class OrderResolver implements Resolve<Order> {
  constructor(private orderService: OrderService) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Order> {
    return this.orderService.getOrderDetails(route.paramMap.get('id')!!);
  }
}
