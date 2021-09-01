import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SignInDto } from 'src/app/dto/dto';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss'],
})
export class SigninComponent implements OnInit {
  validateForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
    });
  }

  async submitForm() {
    if (this.validateForm.valid) {
      const body: SignInDto = {
        Email: this.validateForm.controls.email.value,
        Password: this.validateForm.controls.password.value,
      };
      this.authService.signIn(body).subscribe((resp) => {
        if (resp.token != '') {
          localStorage.setItem('token', resp.token);
          localStorage.setItem('email', body.Email);
          this.router.navigate(['/dashboard/home']);
        } else {
          alert('Login Failed, Make sure you entered valid email and password');
        }
      });
    }
  }
}
