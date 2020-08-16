import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { TestComponent } from './test/test.component'
import { HttpClientModule } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router'
import { routes } from './routes';
import { NavbarComponent } from './navbar/navbar.component'
import { CountoModule } from 'angular2-counto';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component'


@NgModule({
  declarations: [
    AppComponent,
    TestComponent,
    NavbarComponent,
    FooterComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    CountoModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
