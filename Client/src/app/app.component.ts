import {Component, OnDestroy, OnInit} from '@angular/core';
import {AuthService} from './auth/auth.service';
import {User} from './auth/auth.model';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  user: User = {};
  private subscription$: Subscription | undefined;

  constructor(private authService: AuthService) {
  }

  ngOnInit(): void {
    this.subscription$ = this.authService.user$.subscribe(u => this.user = u);
  }

  ngOnDestroy(): void {
    this.subscription$?.unsubscribe();
  }

  get isAuthenticated(): boolean {
    return !!this.user.userName;
  }
}
