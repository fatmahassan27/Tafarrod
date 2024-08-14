import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _HttpClient:HttpClient) { }


  register(form:any):Observable<any>{
    return this._HttpClient.post(`http://localhost:5084/api/Account/Register`, form)
  }
  login(form:any):Observable<any>{
    return this._HttpClient.post(`http://localhost:5084/api/Account`, form)
  }
}
