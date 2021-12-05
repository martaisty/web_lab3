import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from 'rxjs';
import {Book} from '../book';
import {BookService} from '../book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit, OnDestroy {
  private _subscription: Subscription | undefined;

  books: Book[] = [];

  constructor(private service: BookService) {
  }

  ngOnInit(): void {
    this._subscription = this.service.books.subscribe(books => this.books = books);
    this.service.getAllBooks();
  }

  ngOnDestroy(): void {
    this._subscription?.unsubscribe();
  }
}
