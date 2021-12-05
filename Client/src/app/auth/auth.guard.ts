import {Injectable} from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  CanLoad,
  Route,
  Router,
  RouterStateSnapshot,
  UrlSegment,
  UrlTree
} from '@angular/router';
import {Observable} from 'rxjs';
import {JwtHelperService} from '@auth0/angular-jwt';
import {LocalStorageService} from './local-storage.service';

@Injectable()
export class AuthGuard implements CanLoad, CanActivate {
  constructor(
    private jwtHelper: JwtHelperService,
    private storage: LocalStorageService,
    private router: Router) {
  }

  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.accessAllowed((route.data as any).roles || []);
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.accessAllowed((route.data as any).roles || []);
  }

  private accessAllowed(requiredRoles: string[]): boolean | UrlTree {
    const token = this.storage.getToken()?.accessToken;
    const tokenValid = token && !this.jwtHelper.isTokenExpired(token);
    const user = this.storage.getUser();

    if (tokenValid && user) {
      for (const r of requiredRoles) {
        if (!user.roles?.includes(r)) {
          return this.router.createUrlTree(['/login']);
        }
      }
      return true;
    }
    return this.router.createUrlTree(['/login']);
  }
}
