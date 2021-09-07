import { Component, OnInit } from '@angular/core';
import { SubjectService } from '../subject/services/subject.service';
import { TaskService } from './services/task.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.scss'],
})
export class TaskComponent implements OnInit {
  constructor(
    private subjectService: SubjectService,
    private taskService: TaskService
  ) {}

  ngOnInit(): void {
    var selectedSubject = this.subjectService.getSelectedSubject();
    this.subjectId = selectedSubject.subjectId;
    this.subjectName = selectedSubject.subjectName;

    this.taskService.getTasksBySubject(this.subjectId).subscribe((resp) => {
      if (resp) {
        this.listOfTasks = resp;
      }
    });
  }

  subjectId = '';
  subjectName = '';
  listOfTasks: any[] = [{ taskName: 'wkwkwk', isCompleted: true }];
}
