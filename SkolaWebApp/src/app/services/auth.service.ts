import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { SignInDto, SignUpDto } from '../dto/dto';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    private baseService: BaseService,
    private jwtHelper: JwtHelperService
  ) {}

  signUp(body: SignUpDto): Observable<any> {
    return this.baseService.create('User/signup', body);
  }

  signIn(body: SignInDto): Observable<any> {
    return this.baseService.create('User/signin', body);
  }

  getUserDetail(email: string): Observable<any> {
    return this.baseService.read(`User/${email}`);
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token!);
  }
}
