import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {BookListComponent} from './book-list/book-list.component';
import {CartComponent} from './cart/cart.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'books'},
  {path: 'books', component: BookListComponent},
  {path: 'cart', component: CartComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule {
}
