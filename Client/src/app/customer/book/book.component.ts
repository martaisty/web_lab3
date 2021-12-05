import {Component, Input, OnInit} from '@angular/core';
import {Book} from '../_models/book';
import {BookService} from '../_services/book.service';
import {CartService} from '../../_services/cart.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {
  @Input() book: Book = {};
  @Input() quantity: number = 0;

  constructor(private bookService: BookService,
              private cartService: CartService) {
  }

  ngOnInit(): void {
  }

  addToCart() {
    this.quantity++;
    this.cartService.addToCart(this.book.id!!);
  }

  removeFromCart() {
    if (this.quantity <= 0) {
      return;
    }
    this.quantity--;
    this.cartService.removeFromCart(this.book.id!!);
  }
}
