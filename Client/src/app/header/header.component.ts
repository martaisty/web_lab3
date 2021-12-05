import {Component, OnDestroy, OnInit} from '@angular/core';
import {AuthService} from '../auth/auth.service';
import {Router} from '@angular/router';
import {User} from '../auth/auth.model';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy {
  private _userSubscription$: Subscription | undefined;

  user: User = {};

  constructor(private authService: AuthService,
              private router: Router) {
  }

  get fullName(): string {
    return `${this.user.firstName || ''} ${this.user.lastName || ''}`.trim();
  }

  get isAdmin(): boolean {
    return this.user.roles?.includes('ADMIN') || false;
  }

  get isCustomer(): boolean {
    return this.user.roles?.includes('CUSTOMER') || false;
  }

  ngOnInit(): void {
    this._userSubscription$ = this.authService.user$.subscribe(val => this.user = val);
  }

  ngOnDestroy(): void {
    this._userSubscription$?.unsubscribe();
  }

  logout() {
    this.authService.logout().subscribe(() => this.router.navigate(['/']));
  }
}
