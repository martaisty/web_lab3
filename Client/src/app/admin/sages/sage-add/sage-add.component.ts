import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import {Subscription} from 'rxjs';
import {Router} from '@angular/router';
import {BookService} from '../../books/book.service';
import {SageService} from '../sage.service';
import {Book} from '../../books/book';

@Component({
  selector: 'app-sage-add',
  templateUrl: './sage-add.component.html',
  styleUrls: ['./sage-add.component.scss']
})
export class SageAddComponent implements OnInit, OnDestroy {
  form: FormGroup = new FormGroup({
    name: new FormControl('', [Validators.required]),
    age: new FormControl('', [Validators.required]),
    city: new FormControl('', [Validators.required]),
    books: new FormArray([]),
  });

  books: Book[] = [];

  private booksSubscription$: Subscription | undefined;

  constructor(private router: Router,
              private bookService: BookService,
              private sageService: SageService) {
  }

  ngOnInit(): void {
    this.bookService.getAllBooks();
    this.booksSubscription$ = this.bookService.books.subscribe(val => this.populateBooks(val));
  }

  ngOnDestroy(): void {
    this.booksSubscription$?.unsubscribe();
  }

  populateBooks(books: Book[]) {
    const booksControl = this.form.get('books') as FormArray;
    books.forEach(() => booksControl.push(new FormControl(false)))
    this.books = books;
  }

  getError(errorCode: string, path: string) {
    return this.form.getError(errorCode, path);
  }

  addSage() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    const value = {
      ...this.form.value,
      books: this.books
        .filter((_, i) => this.form.value.books[i])
        .map(it => it.id)
    }
    this.sageService.addSage(value);
    this.router.navigate(['/admin/sages']);
  }

  cancelAdding() {
    this.router.navigate(['/admin/sages']);
  }

}
