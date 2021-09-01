import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateTermDto } from 'src/app/dto/dto';
import { BaseService } from 'src/app/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class TermService {
  constructor(private baseService: BaseService) {}

  getUserTerms(userId: string): Observable<any> {
    return this.baseService.read(`Term/User/${userId}`);
  }

  createNewTerm(newTerm: CreateTermDto): Observable<any> {
    return this.baseService.create('Term', newTerm);
  }

  deleteTerm(termId: string): Observable<any> {
    return this.baseService.delete(`Term/${termId}`);
  }
}
