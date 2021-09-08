import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateTaskDto } from 'src/app/dto/dto';
import { BaseService } from 'src/app/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  constructor(private baseService: BaseService) {}

  getTasksBySubject(subjectId: string): Observable<any> {
    return this.baseService.read(`Task/${subjectId}`);
  }

  createNewTask(newTask: CreateTaskDto): Observable<any> {
    return this.baseService.create(`Task`, newTask);
  }

  setTaskCompleteStatus(taskId: string): Observable<any> {
    return this.baseService.update(`Task/SetComplete/${taskId}`, {});
  }

  deleteTask(taskId: string): Observable<any> {
    return this.baseService.delete(`Task/${taskId}`);
  }
}
