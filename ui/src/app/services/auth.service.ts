import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

interface TokenResponse {
  accessToken: string;
  refreshToken: string;
}

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  apiUrl = 'https://localhost:5001/api/auth';
  constructor(readonly http: HttpClient) { }

  login(username: string, password: string) {
    const jsonBody = JSON.stringify({username, password});
    this.http.post(`${this.apiUrl}/authenticate`, jsonBody)
             .subscribe( (response: TokenResponse) => {
               console.log('accessToken:', response.accessToken);
               console.log('refreshToken:', response.refreshToken);
             });
  }
}
