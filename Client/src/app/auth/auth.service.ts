import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AuthDto, User} from './auth.model';
import {BehaviorSubject, Observable} from 'rxjs';
import {environment as env} from '../../environments/environment';
import {LocalStorageService} from './local-storage.service';
import {tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _user = new BehaviorSubject<User>({});

  get user$(): Observable<User> {
    return this._user.asObservable();
  }

  get user(): User {
    return this._user.getValue();
  }

  constructor(private http: HttpClient,
              private localStorageService: LocalStorageService) {
    this._user.next(localStorageService.getUser() || {});
  }

  login(user: User): Observable<AuthDto> {
    return this.http.post<AuthDto>(`${env.apiUrl}/Authentication/login`, user)
      .pipe(tap(val => this.saveAuthResult(val)));
  }

  register(user: User): Observable<AuthDto> {
    return this.http.post<AuthDto>(`${env.apiUrl}/Authentication/register`, user)
      .pipe(tap(val => this.saveAuthResult(val)));
  }

  logout(): Observable<any> {
    return this.http.post(`${env.apiUrl}/Authentication/logout`, null, {withCredentials: true})
      .pipe(tap(() => this.clearStorage()));
  }

  clearStorage() {
    this._user.next({});
    this.localStorageService.logout();
  }

  private saveAuthResult(val: AuthDto): void {
    this._user.next(val.user);
    this.localStorageService.saveUser(val.user);
    this.localStorageService.saveToken({
      accessToken: val.accessToken,
    });
  }
}
