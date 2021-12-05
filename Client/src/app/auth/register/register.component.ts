import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerFailed = false;

  form: FormGroup = new FormGroup({
    userName: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required])
  });

  constructor(private authService: AuthService,
              private router: Router,) {
  }

  ngOnInit(): void {
  }

  getError(errorCode: string, path: string) {
    return this.form.getError(errorCode, path);
  }

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.authService.register(this.form.value).subscribe(
      res => {
        this.registerFailed = false;
        this.router.navigate(['/']);
      },
      err => {
        this.registerFailed = true;
        this.form.reset({});
      }
    )
  }
}
