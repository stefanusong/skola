import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateSubjectDto } from 'src/app/dto/dto';
import { BaseService } from 'src/app/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class SubjectService {
  constructor(private baseService: BaseService) {}

  selectedSubjectId = '';
  selectedSubjectName = '';

  getSubjectByTerm(termId: string): Observable<any> {
    return this.baseService.read(`Subject/${termId}`);
  }

  createNewSubject(body: CreateSubjectDto): Observable<any> {
    return this.baseService.create('Subject', body);
  }

  addSelectedSubject(subjectId: string, subjectName: string) {
    this.selectedSubjectId = subjectId;
    this.selectedSubjectName = subjectName;
  }

  getSelectedSubject() {
    return {
      subjectId: this.selectedSubjectId,
      subjectName: this.selectedSubjectName,
    };
  }
}
