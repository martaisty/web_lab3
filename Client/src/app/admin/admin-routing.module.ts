import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {BookListComponent} from './books/book-list/book-list.component';
import {BookDetailsComponent} from './books/book-details/book-details.component';
import {BookResolver} from './books/book.resolver';
import {BookEditComponent} from './books/book-edit/book-edit.component';
import {BookAddComponent} from './books/book-add/book-add.component';
import {SageListComponent} from './sages/sage-list/sage-list.component';
import {SageAddComponent} from './sages/sage-add/sage-add.component';
import {SageDetailsComponent} from './sages/sage-details/sage-details.component';
import {SageResolver} from './sages/sage.resolver';
import {SageEditComponent} from './sages/sage-edit/sage-edit.component';
import {OrderListComponent} from './orders/order-list/order-list.component';
import {OrderDetailsComponent} from './orders/order-details/order-details.component';
import {OrderResolver} from './orders/order.resolver';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'books'},
  {path: 'books', component: BookListComponent},
  {path: 'books/add', component: BookAddComponent},
  {
    path: 'books/:id',
    component: BookDetailsComponent,
    resolve: {
      book: BookResolver
    }
  },
  {
    path: 'books/:id/edit',
    component: BookEditComponent,
    resolve: {
      book: BookResolver,
    }
  },
  {path: 'sages', component: SageListComponent},
  {path: 'sages/add', component: SageAddComponent},
  {
    path: 'sages/:id',
    component: SageDetailsComponent,
    resolve: {
      sage: SageResolver
    }
  },
  {
    path: 'sages/:id/edit',
    component: SageEditComponent,
    resolve: {
      sage: SageResolver,
    }
  },
  {
    path: 'orders',
    component: OrderListComponent,
  },
  {
    path: 'orders/:id',
    component: OrderDetailsComponent,
    resolve: {
      order: OrderResolver
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {
}
