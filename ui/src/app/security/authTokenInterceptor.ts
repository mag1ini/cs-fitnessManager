import {Injectable} from '@angular/core';
import {AuthService} from '../services/auth.service';
import {HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable()
export class AuthTokenInterceptor implements HttpInterceptor{

  constructor(readonly authService: AuthService) {
   // authService.$accessToken.value;
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log('intercepted');

    const reqWithAuth = req.clone({
      headers: new HttpHeaders({
        Autorization: `Bearer ${this.authService.$accessToken.value}`,
        'Content-Type': 'application/json; charset=utf8',
      })
    });
   // reqWithAuth.headers = new HttpHeaders({Authorization, `Bearer ${this.authService.$accessToken.value}`});
    //req.headers.set('Authorization', `Bearer ${this.authService.$accessToken.value}`);
    return next.handle(reqWithAuth);
  }
}
