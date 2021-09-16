import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { TaskService } from '../task/services/task.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.getStatistic();
  }

  totalTerms: number = 0; 
  totalSubjects: number = 0;
  totalTasks: number = 0;
  totalActiveTasks: number = 0;
  totalCompleted: number = 0;
  totalIncomplete: number = 0;
  totalArchived: number = 0;
  onProgressPercentage: number = 0; 
  completedPercentage: number = 0;

  getStatistic() {
    this.taskService
      .getStatistics(localStorage.getItem('userid') || '')
      .subscribe((resp) => {
        if (resp) {
          this.totalTerms = resp.totalTerms;
          this.totalSubjects = resp.totalSubjects;
          this.totalTasks = resp.totalTasks;
          this.totalActiveTasks = resp.totalActiveTasks;
          this.totalCompleted = resp.totalCompleted;
          this.totalIncomplete = resp.totalIncomplete;
          this.totalArchived = resp.totalArchived;
          this.onProgressPercentage = resp.onProgressPercentage;
          this.completedPercentage = resp.completedPercentage;
        }
      });
  }
}
