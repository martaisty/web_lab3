import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import {Sage} from '../../sages/sage';
import {Subscription} from 'rxjs';
import {Router} from '@angular/router';
import {BookService} from '../book.service';
import {SageService} from '../../sages/sage.service';

@Component({
  selector: 'app-book-add',
  templateUrl: './book-add.component.html',
  styleUrls: ['./book-add.component.scss']
})
export class BookAddComponent implements OnInit, OnDestroy {
  form: FormGroup = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    sages: new FormArray([]),
  });

  sages: Sage[] = [];

  private sagesSubscription$: Subscription | undefined;

  constructor(private router: Router,
              private bookService: BookService,
              private sageService: SageService) {
  }

  ngOnInit(): void {
    this.sageService.getAllSages();
    this.sagesSubscription$ = this.sageService.sages.subscribe(val => this.populateSages(val));
  }

  ngOnDestroy(): void {
    this.sagesSubscription$?.unsubscribe();
  }

  populateSages(sages: Sage[]) {
    const sagesControl = this.form.get('sages') as FormArray;
    sages.forEach(() => sagesControl.push(new FormControl(false)))
    this.sages = sages;
  }

  getError(errorCode: string, path: string) {
    return this.form.getError(errorCode, path);
  }

  addBook() {
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
    this.bookService.addBook(value);
    this.router.navigate(['/admin/books']);
  }

  cancelAdding() {
    this.router.navigate(['/admin/books']);
  }
}
