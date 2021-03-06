import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {AuthTokenInterceptor} from './security/authTokenInterceptor';
import { AddCoachComponent } from './coach/add/add-coach.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AddCoachComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthTokenInterceptor,
    multi: true,
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
