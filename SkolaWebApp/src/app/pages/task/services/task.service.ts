import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  constructor(private baseService: BaseService) {}

  getTasksBySubject(subjectId: string): Observable<any> {
    return this.baseService.read(`Task/${subjectId}`);
  }
}
