import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {AdminRoutingModule} from './admin-routing.module';
import {BookListComponent} from './books/book-list/book-list.component';
import {BookService} from './books/book.service';
import {BookComponent} from './books/book/book.component';
import {MatCardModule} from '@angular/material/card';
import {BookResolver} from './books/book.resolver';
import {BookDetailsComponent} from './books/book-details/book-details.component';
import {MatListModule} from '@angular/material/list';
import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';
import {BookEditComponent} from './books/book-edit/book-edit.component';
import {SageService} from './sages/sage.service';
import {ReactiveFormsModule} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {BookAddComponent} from './books/book-add/book-add.component';
import {SageResolver} from './sages/sage.resolver';
import {SageListComponent} from './sages/sage-list/sage-list.component';
import {SageComponent} from './sages/sage/sage.component';
import {SageAddComponent} from './sages/sage-add/sage-add.component';
import {SageDetailsComponent} from './sages/sage-details/sage-details.component';
import {SageEditComponent} from './sages/sage-edit/sage-edit.component';
import {OrderListComponent} from './orders/order-list/order-list.component';
import {OrderDetailsComponent} from './orders/order-details/order-details.component';
import {OrderService} from './orders/order.service';
import {OrderResolver} from './orders/order.resolver';


@NgModule({
  declarations: [
    BookListComponent,
    BookComponent,
    BookDetailsComponent,
    BookEditComponent,
    BookAddComponent,
    SageListComponent,
    SageComponent,
    SageAddComponent,
    SageDetailsComponent,
    SageEditComponent,
    OrderListComponent,
    OrderDetailsComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatCardModule,
    MatListModule,
    MatTableModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule
  ],
  providers: [
    BookService,
    BookResolver,
    SageService,
    SageResolver,
    OrderService,
    OrderResolver,
  ]
})
export class AdminModule {
}
