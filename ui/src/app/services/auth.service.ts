import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {HttpHeaders} from '@angular/common/http';
import {BehaviorSubject} from 'rxjs';

interface TokenResponse {
  accessToken: string;
}

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  apiUrl = 'https://localhost:5001/api/auth';

  readonly $accessToken = new BehaviorSubject<string>(null);

  constructor(readonly http: HttpClient) { }

  login(username: string, password: string) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf8'
    });

    const jsonBody = JSON.stringify({username, password});
    this.http.post(`${this.apiUrl}/authenticate`, jsonBody, {headers})
             .subscribe( (response: TokenResponse) => {
         console.log('accessToken:', response.accessToken);
         this.$accessToken.next(response.accessToken);
     });

  }
}
