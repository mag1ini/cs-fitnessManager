import {Injectable} from '@angular/core';
import {AuthService} from '../services/auth.service';
import {HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {EMPTY, Observable} from 'rxjs';

@Injectable()
export class AuthTokenInterceptor implements HttpInterceptor {
  requestTimeoutMilliSeconds = 30 * 1000;
  awaitedRequests: HttpRequest<any>[] = [];
  isRefreshInProgress = false;

  constructor(readonly authService: AuthService) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log('intercepted');

    if (!this.isTokenExpired()) {
      console.log(`token is not expired, making request`);
      return next.handle(this.injectAuthHeader(req));
    } else {
      console.log(`token expired`);

      if (this.isRefreshInProgress) {
        console.log(`enqueue req to url ${req.url}`);
        this.awaitedRequests.push(req);
        return EMPTY;
      } else {
        console.log(`refreshing token`);

        this.isRefreshInProgress = true;
        this.authService.refresh().subscribe(() => {

          console.log(`refreshing successful`);

          const reqWithAuth = this.injectAuthHeader(req);
          for (const request of this.awaitedRequests) {
            console.log(`make req to url ${req.url}`);
            next.handle(this.injectAuthHeader(request));
          }

          this.awaitedRequests = [];
          this.isRefreshInProgress = false;
          return next.handle(reqWithAuth);
        });
      }
    }

  }

  isTokenExpired() {
    return this.authService.$userInfo.value
      && this.authService.$userInfo.value.expires < (new Date(Date.now() - this.requestTimeoutMilliSeconds));
  }

  injectAuthHeader(req: HttpRequest<any>) {
    return req.clone({
      headers: new HttpHeaders({
        Autorization: `Bearer ${this.authService.$accessToken.value}`,
        'Content-Type': 'application/json; charset=utf8',
      })
    });
  }

}
