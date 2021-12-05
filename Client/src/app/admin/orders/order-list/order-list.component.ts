import {Component, OnInit} from '@angular/core';
import {OrderService} from '../order.service';
import {Order} from '../order';
import {User} from '../../../auth/auth.model';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit {
  orders: Order[] = [];

  constructor(private orderService: OrderService,
              private router: Router,
              private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.orderService.getAllOrders().subscribe(val => this.orders = val);
  }

  fullName(user: User): string {
    return `${user.firstName || ''} ${user.lastName || ''}`.trim();
  }

  details(id: string) {
    this.router.navigate([id], {relativeTo: this.route});
  }
}
