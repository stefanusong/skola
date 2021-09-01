import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { SignUpDto } from 'src/app/dto/dto';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit {
  constructor(private fb: FormBuilder, private authService: AuthService) {}

  validateForm!: FormGroup;

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      email: [null, [Validators.email, Validators.required]],
      password: [null, [Validators.required, Validators.minLength(6)]],
      checkPassword: [null, [Validators.required, this.confirmationValidator]],
      fullname: [null, [Validators.required]],
    });
  }

  updateConfirmValidator(): void {
    /** wait for refresh value */
    Promise.resolve().then(() =>
      this.validateForm.controls.checkPassword.updateValueAndValidity()
    );
  }

  confirmationValidator = (control: FormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { required: true };
    } else if (control.value !== this.validateForm.controls.password.value) {
      return { confirm: true, error: true };
    }
    return {};
  };

  submitForm(): void {
    if (this.validateForm.valid) {
      const body: SignUpDto = {
        FullName: this.validateForm.controls.fullname.value,
        Email: this.validateForm.controls.email.value,
        Password: this.validateForm.controls.password.value,
        ConfirmedPassword: this.validateForm.controls.checkPassword.value
      };
      this.authService.signUp(body).subscribe((resp) => {
        if (resp.succeeded == true) {
          alert("User registered successfuly")
        } else {
          alert("Failed to register" + resp.errors)
        }
      });
    }
  }
}
