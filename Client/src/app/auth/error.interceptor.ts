import {Injectable} from '@angular/core';
import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {Router} from '@angular/router';
import {catchError} from 'rxjs/operators';
import {AuthService} from './auth.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService, private router: Router) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(request)
      .pipe(catchError((error: HttpErrorResponse) => {
        const errorMessage = this.handleError(error);
        return throwError(errorMessage);
      }));
  }

  private handleError = (error: HttpErrorResponse): string => {
    switch (error.status) {
      case 401:
        return this.handleUnauthorized(error);
      default:
        return 'unknown';
    }
  }

  private handleUnauthorized = (error: HttpErrorResponse) => {
    this.authService.clearStorage();
    if (this.router.url.endsWith('/login')) {
      return 'Authentication failed. Wrong Username or Password';
    } else {
      this.router.navigate(['/login'], {queryParams: {returnUrl: this.router.url}});
      return error.message;
    }
  }
}
