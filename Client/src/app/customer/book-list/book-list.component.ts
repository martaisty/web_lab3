import {Component, OnDestroy, OnInit} from '@angular/core';
import {combineLatest, Subscription} from 'rxjs';
import {Book} from '../_models/book';
import {BookService} from '../_services/book.service';
import {Cart, CartService} from '../../_services/cart.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit, OnDestroy {
  private _subscription: Subscription | undefined;

  books: Book[] = [];
  cart: Cart = {};

  constructor(private bookService: BookService,
              private cartService: CartService) {
  }

  ngOnInit(): void {
    this.cartService.fetchCart();
    this.bookService.getAllBooks();

    this._subscription = combineLatest([
      this.cartService.cart$,
      this.bookService.books$
    ])
      .subscribe(val => {
        this.cart = val[0];
        this.books = val[1];
      })
  }

  ngOnDestroy(): void {
    this._subscription?.unsubscribe();
  }
}
