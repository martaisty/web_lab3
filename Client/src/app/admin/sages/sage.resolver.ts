import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, Resolve, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs';
import {Sage} from './sage';
import {SageService} from './sage.service';

@Injectable()
export class SageResolver implements Resolve<Sage> {
  constructor(private sageService: SageService) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Sage> {
    return this.sageService.getSage(route.paramMap.get('id') || '');
  }
}
