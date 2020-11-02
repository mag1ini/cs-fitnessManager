import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {HttpHeaders} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {map, tap} from 'rxjs/operators';
import jwt_decode from 'jwt-decode';
import UserInfo from '../security/userInfo';


interface TokenResponse {
  accessToken: string;
}

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  apiUrl = 'https://localhost:5001/api/auth';
  storageKey = 'userInfo';

  readonly $accessToken = new BehaviorSubject<string>(null);
  readonly $userInfo = new BehaviorSubject<UserInfo>(null);

  constructor(readonly http: HttpClient) {
    this.$userInfo
      .pipe(tap(userInfo => {
        if (userInfo) {
          localStorage[this.storageKey] = JSON.stringify(userInfo);
        }
      })).subscribe();
  }

  login(username: string, password: string){
    const headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf8'});
    const jsonBody = JSON.stringify({username, password});
    this.http.post(`${this.apiUrl}/authenticate`, jsonBody,{headers}).pipe(tap(this.processToken.bind(this)))
      .subscribe();
  }

  refresh(){
    if (!localStorage[this.storageKey])  { return null; }
    const headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf8'});
    this.http.post(`${this.apiUrl}/refresh`, {}, {headers})
      .pipe(tap(this.processToken.bind(this)))
      .subscribe();

  }

  processToken(response: TokenResponse) {
    console.log(response);
    const token = response.accessToken;
    this.$accessToken.next(token);
    this.$userInfo.next(new UserInfo(jwt_decode(token)));
  }




}
