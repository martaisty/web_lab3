import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {AuthService} from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginFailed = false;
  private _returnUrl = '/';

  form: FormGroup = new FormGroup({
    userName: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });

  constructor(private authService: AuthService,
              private router: Router,
              private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this._returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  getError(errorCode: string, path: string) {
    return this.form.getError(errorCode, path);
  }

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.authService.login(this.form.value).subscribe(
      res => {
        this.loginFailed = false;
        this.router.navigate([this._returnUrl]);
      },
      err => {
        this.loginFailed = true;
        this.form.reset({});
      }
    )
  }

}
