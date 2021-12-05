import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {CustomerRoutingModule} from './customer-routing.module';
import {BookComponent} from './book/book.component';
import {BookListComponent} from './book-list/book-list.component';
import {CartComponent} from './cart/cart.component';
import {BookService} from './_services/book.service';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';


@NgModule({
  declarations: [
    BookComponent,
    BookListComponent,
    CartComponent
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule
  ],
  providers: [
    BookService,
  ]
})
export class CustomerModule {
}
