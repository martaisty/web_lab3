import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import {Book} from '../../books/book';
import {Subscription} from 'rxjs';
import {ActivatedRoute, Router} from '@angular/router';
import {BookService} from '../../books/book.service';
import {SageService} from '../sage.service';
import {Sage} from '../sage';

@Component({
  selector: 'app-sage-edit',
  templateUrl: './sage-edit.component.html',
  styleUrls: ['./sage-edit.component.scss']
})
export class SageEditComponent implements OnInit, OnDestroy {
  form: FormGroup = new FormGroup({
    id: new FormControl({value: ''}),
    name: new FormControl('', [Validators.required]),
    age: new FormControl('', [Validators.required]),
    city: new FormControl('', [Validators.required]),
    books: new FormArray([]),
  });

  books: Book[] = [];
  sage: Sage = {};

  private booksSubscription$: Subscription | undefined;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private bookService: BookService,
              private sageService: SageService) {
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.sage = data.sage;
      const sageNoBooks = {...data.sage};
      delete sageNoBooks.books;
      this.form.patchValue(sageNoBooks);
    });
    this.bookService.getAllBooks();
    this.booksSubscription$ = this.bookService.books.subscribe(val => this.populateBooks(val));
  }

  ngOnDestroy(): void {
    this.booksSubscription$?.unsubscribe();
  }

  populateBooks(books: Book[]) {
    const booksControl = this.form.get('books') as FormArray;
    books.forEach(val => booksControl.push(new FormControl(this.bookSelected(val.id!!))))
    this.books = books;
  }

  private bookSelected(bookId: string): boolean {
    return !!this.sage.books?.find(val => val.id === bookId);
  }

  getError(errorCode: string, path: string) {
    return this.form.getError(errorCode, path);
  }

  updateSage() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    console.log(this.form.value);
    console.log('filtered books', this.books
      .filter((_, i) => this.form.value.books[i]));
    const value = {
      ...this.form.value,
      books: this.books
        .filter((_, i) => this.form.value.books[i])
        .map(it => it.id)
    }
    this.sageService.updateSage(value);
    this.router.navigate(['/admin/sages']);
  }

  cancelAdding() {
    this.router.navigate(['/admin/sages']);
  }

}
