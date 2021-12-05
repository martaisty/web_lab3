import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, Resolve, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs';
import {BookService} from './book.service';
import {Book} from './book';

@Injectable()
export class BookResolver implements Resolve<Book> {
  constructor(private bookService: BookService) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Book> {
    return this.bookService.getBook(route.paramMap.get('id') || '');
  }
}
