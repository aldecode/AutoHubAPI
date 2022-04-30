import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './home-page/home-page.component';
import { RouterModule } from "@angular/router";

@NgModule({
  declarations: [
    HomePageComponent
  ],
    imports: [
        CommonModule,
        RouterModule
    ]
})
export class ApplicationModule { }
