import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  public loginForm: FormGroup;
  public showPass: boolean = false;

  constructor(private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.loginForm = this.formBuilder.group({
      emailAddress: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  public get emailAddress(): AbstractControl {
    return this.loginForm.get('emailAddress');
  }

  public get password(): AbstractControl {
    return this.loginForm.get('password');
  }

  public toggleShowPass(): void {
    this.showPass = !this.showPass;
  }

  public async validateForm(): Promise<void> {
    console.log(this.emailAddress.value);
    this.loginForm.updateValueAndValidity();
    this.loginForm.markAllAsTouched();
    if (!this.loginForm.valid) {
      return;
    }
  }
}
