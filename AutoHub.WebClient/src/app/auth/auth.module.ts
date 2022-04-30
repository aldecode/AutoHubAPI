import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginPageComponent } from './login/login-page.component';
import { RegistrationPageComponent } from './registration/registration-page.component';
import { SharedModule } from '../shared/shared.module';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  declarations: [
    LoginPageComponent,
    RegistrationPageComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    MatButtonModule
  ]
})
export class AuthModule {
}
