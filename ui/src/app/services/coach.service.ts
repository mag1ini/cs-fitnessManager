import { Injectable } from '@angular/core';
import TrainingType from '../domain/trainingTypes';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CoachService {
  apiUrl = 'https://localhost:5003/api/coach';

  constructor(readonly http: HttpClient) { }

  add(firstname: string, lastname: string, trainingType: TrainingType): Promise<any> {
    const jsonBody = JSON.stringify( {firstname, lastname, Speciality: trainingType} );
    const headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf8'});
    return this.http.post(`${this.apiUrl}`, jsonBody, {headers}).toPromise();


  }
}
