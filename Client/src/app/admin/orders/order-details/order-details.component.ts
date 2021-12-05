import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Order} from '../order';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss']
})
export class OrderDetailsComponent implements OnInit {
  order: Order = {};

  constructor(private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.order = this.route.snapshot.data.order;
  }

  get fullName(): string {
    return `${this.order.customer?.firstName || ''} ${this.order.customer?.lastName || ''}`.trim();
  }
}
