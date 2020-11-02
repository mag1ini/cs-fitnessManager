import {Injectable} from '@angular/core';
import {AuthService} from '../services/auth.service';
import {HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {EMPTY, Observable, Subject} from 'rxjs';
import {switchMap, take} from 'rxjs/operators';

@Injectable()
export class AuthTokenInterceptor implements HttpInterceptor {
  requestTimeoutMilliSeconds = 30 * 1000;
  awaitedRequests: HttpRequest<any>[] = [];
  isRefreshInProgress = false;
  $refreshSubject = new Subject<boolean>();

  constructor(readonly authService: AuthService) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log('intercepted');

    if (!this.isTokenExpired()) {
      console.log(`token is not expired, making request`);
      return next.handle(this.injectAuthHeader(req));
  //    return next.handle(this.injectAuthHeader(req));
    }

    if (req.url.includes('/api/auth/')) {
      return next.handle(req);
    }
      console.log(`token expired`);

      if (!this.isRefreshInProgress) {

        console.log(`refreshing token`);

        this.isRefreshInProgress = true;

        return this.authService.refresh()
          .pipe(switchMap(() => {
            console.log('refresh successful');
            this.$refreshSubject.next(true);
            this.isRefreshInProgress = false;
            return next.handle(this.injectAuthHeader(req));

          }));
      }
      return this.$refreshSubject.pipe(
        take(1),
        switchMap(() => next.handle(this.injectAuthHeader(req))));

  }

  isTokenExpired() {
    return this.authService.$userInfo.value
      && this.authService.$userInfo.value.expires
      && this.authService.$userInfo.value.expires < (new Date(Date.now() - this.requestTimeoutMilliSeconds));
  }

  injectAuthHeader(req: HttpRequest<any>): HttpRequest<any> {

    console.log(`injecting auth`, this.authService.$accessToken.value);
    return !this.authService.$accessToken.value
      ? req
      : req.clone({headers: new HttpHeaders({authorization: `Bearer ${this.authService.$accessToken.value}`})});


  }

}
