import {Component, OnDestroy, OnInit} from '@angular/core';
import {combineLatest, Subscription} from 'rxjs';
import {Book} from '../_models/book';
import {Cart, CartService} from '../../_services/cart.service';
import {BookService} from '../_services/book.service';
import {Router} from '@angular/router';
import {OrderBook} from '../_models/order';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit, OnDestroy {
  private _subscription: Subscription | undefined;

  books: Book[] = [];
  cart: Cart = {};

  constructor(private bookService: BookService,
              private cartService: CartService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.cartService.fetchCart();
    this.bookService.getAllBooks();
    this._subscription = combineLatest([
      this.cartService.cart$,
      this.bookService.books$
    ])
      .subscribe(val => {
        console.log(val);
        this.cart = val[0];
        this.books = val[1].filter(it => !!val[0][it.id!!]);
      })
  }

  ngOnDestroy(): void {
    this._subscription?.unsubscribe();
  }

  order() {
    const books: OrderBook[] = Object.keys(this.cart)
      .map(it => {
        return {
          bookId: it,
          quantity: this.cart[it]
        }
      })
    this.bookService.order({books}).subscribe(() =>
      this.router.navigate(['/customer/books'])
    );

  }

  get cartNonEmpty(): boolean {
    return Object.keys(this.cart).length > 0;
  }
}
