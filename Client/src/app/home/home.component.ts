import {Component, OnInit} from '@angular/core';
import {AuthService} from '../auth/auth.service';
import {User} from '../auth/auth.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  user: User = {};

  constructor(private authService: AuthService) {
  }

  ngOnInit(): void {
    this.user = this.authService.user;
  }

  get fullName(): string {
    return `${this.user.firstName || ''} ${this.user.lastName || ''}`.trim();
  }


}
