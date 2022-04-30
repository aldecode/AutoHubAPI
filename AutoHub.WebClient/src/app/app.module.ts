import { HttpClientModule } from '@angular/common/http';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { AuthModule } from './auth/auth.module';
import { AppRoutingModule } from './app-routing.module';
import { ApplicationModule } from './application/application.module';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import '@vaadin/app-layout';
import '@vaadin/email-field';
import '@vaadin/vertical-layout';
import '@vaadin/text-field';
import '@vaadin/password-field';
import '@vaadin/form-layout';

@NgModule({
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    AuthModule,
    ApplicationModule,
    RouterModule,
    BrowserAnimationsModule
  ],
  exports: [
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})


export class AppModule { }
