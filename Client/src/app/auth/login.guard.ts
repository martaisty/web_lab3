import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import {Observable} from 'rxjs';
import {LocalStorageService} from './local-storage.service';

@Injectable()
export class LoginGuard implements CanActivate {
  constructor(private storage: LocalStorageService,
              private router: Router) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const user = this.storage.getUser();
    if (user) {
      return this.router.createUrlTree(['/']);
    }
    return true;
  }

}
