import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BaseService {
  constructor(private http: HttpClient) {}

  read(route: string): Observable<any> {
    return this.http.get(`${environment.apiUrl}/api/${route}`);
  }

  create(route: string, payload: any): Observable<any> {
    return this.http.post(`${environment.apiUrl}/api/${route}`, payload);
  }

  update(route: string, payload: any): Observable<any> {
    return this.http.put(`${environment.apiUrl}/api/${route}`, payload);
  }

  delete(route: string): Observable<any> {
    return this.http.delete(`${environment.apiUrl}/api/${route}`);
  }
}
