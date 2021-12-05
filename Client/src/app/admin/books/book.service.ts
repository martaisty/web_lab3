import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';
import {Book, BookUpdate} from './book';
import {HttpClient} from '@angular/common/http';
import {environment as env} from '../../../environments/environment';

@Injectable()
export class BookService {
  private readonly _books = new BehaviorSubject<Book[]>([]);

  constructor(private http: HttpClient) {
  }

  get books(): Observable<Book[]> {
    return this._books.asObservable();
  }

  get booksSnapshot(): Book[] {
    return this._books.getValue();
  }

  getAllBooks() {
    this.http.get<Book[]>(`${env.apiUrl}/admin/Books`)
      .subscribe(books => this._books.next(books));
  }

  getBook(id: string): Observable<Book> {
    return this.http.get<Book>(`${env.apiUrl}/admin/Books/${id}`);
  }

  addBook(newBook: BookUpdate) {
    this.http.post<Book>(`${env.apiUrl}/admin/Books`, newBook)
      .subscribe(book => this._books.next(this.booksSnapshot.concat(book)));
  }

  updateBook(newBook: BookUpdate) {
    this.http.put<Book>(`${env.apiUrl}/admin/Books`, newBook)
      .subscribe(book => this._books.next(this.booksSnapshot.map(it => it.id === newBook.id ? book : it)));
  }

  deleteBook(id: string) {
    this.http.delete(`${env.apiUrl}/admin/Books/${id}`)
      .subscribe(() => this._books.next(this.booksSnapshot.filter(p => p.id !== id)));
  }

}
