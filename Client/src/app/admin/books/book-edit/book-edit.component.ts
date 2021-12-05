import {Component, OnDestroy, OnInit} from '@angular/core';
import {Book} from '../book';
import {ActivatedRoute, Router} from '@angular/router';
import {BookService} from '../book.service';
import {Sage} from '../../sages/sage';
import {SageService} from '../../sages/sage.service';
import {Subscription} from 'rxjs';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.scss']
})
export class BookEditComponent implements OnInit, OnDestroy {
  form: FormGroup = new FormGroup({
    id: new FormControl({value: ''}),
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    sages: new FormArray([]),
  });

  sages: Sage[] = [];
  book: Book = {};

  private sagesSubscription$: Subscription | undefined;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private bookService: BookService,
              private sageService: SageService) {
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.book = data.book;
      const bookNoSages = {...data.book};
      delete bookNoSages.sages;
      this.form.patchValue(bookNoSages);
    });
    this.sageService.getAllSages();
    this.sagesSubscription$ = this.sageService.sages.subscribe(val => this.populateSages(val));
  }

  ngOnDestroy(): void {
    this.sagesSubscription$?.unsubscribe();
  }

  populateSages(sages: Sage[]) {
    const sagesControl = this.form.get('sages') as FormArray;
    sages.forEach(val => sagesControl.push(new FormControl(this.sageSelected(val.id!!))))
    this.sages = sages;
  }

  private sageSelected(sageId: string): boolean {
    return !!this.book.sages?.find(val => val.id === sageId);
  }

  getError(errorCode: string, path: string) {
    return this.form.getError(errorCode, path);
  }


  updateBook() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    const value = {
      ...this.form.value,
      sages: this.sages
        .filter((_, i) => this.form.value.sages[i])
        .map(it => it.id)
    }
    this.bookService.updateBook(value);
    this.router.navigate(['/admin/books']);
  }

  cancelEdit() {
    this.router.navigate(['/admin/books']);
  }
}
