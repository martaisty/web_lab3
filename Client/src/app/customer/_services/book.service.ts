import {Injectable} from '@angular/core';
import {Observable, Subject} from 'rxjs';
import {Book} from '../_models/book';
import {HttpClient} from '@angular/common/http';
import {environment as env} from '../../../environments/environment';
import {Order} from '../_models/order';

@Injectable()
export class BookService {
  private readonly _books$ = new Subject<Book[]>();

  constructor(private http: HttpClient) {
  }

  get books$(): Observable<Book[]> {
    return this._books$.asObservable();
  }

  getAllBooks() {
    this.http.get<Book[]>(`${env.apiUrl}/customer/Books`)
      .subscribe(books => this._books$.next(books));
  }

  order(order: Order): Observable<unknown> {
    return this.http.post(`${env.apiUrl}/customer/orders`, order, {withCredentials: true});
  }
}
