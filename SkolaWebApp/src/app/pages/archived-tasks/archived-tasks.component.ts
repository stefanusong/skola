import { Component, OnInit } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { TaskService } from '../task/services/task.service';

@Component({
  selector: 'app-archived-tasks',
  templateUrl: './archived-tasks.component.html',
  styleUrls: ['./archived-tasks.component.scss'],
})
export class ArchivedTasksComponent implements OnInit {
  constructor(
    private taskService: TaskService,
    private modal: NzModalService
  ) {}

  ngOnInit(): void {
    this.isLoadingTasks = true;
    this.getArchivedTasks();
  }

  archivedTasks: any[] = [];
  isLoadingTasks = false;

  // API CALLS
  getArchivedTasks() {
    this.taskService.getArchivedTask().subscribe((resp) => {
      if (resp) {
        this.archivedTasks = resp;
        this.isLoadingTasks = false;
      }
    });
  }

  unarchiveTask(taskId: string) {
    this.taskService.archiveTask(taskId).subscribe((resp) => {
      if (resp) {
        this.getArchivedTasks();
      }
    });
  }

  deleteTask(taskId: string) {
    this.taskService.deleteTask(taskId).subscribe((resp) => {
      if (resp) {
        this.getArchivedTasks();
      }
    });
  }

  // MODALS

  showUnarchiveTaskModal(taskId: string) {
    this.modal.confirm({
      nzTitle: 'Are you sure to UNARCHIVE(Restore) the selected task?',
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: async () => await this.unarchiveTask(taskId),
      nzCancelText: 'No',
      nzOnCancel: () => console.log('Cancel'),
    });
  }

  showDeleteTaskModal(taskId: string) {
    this.modal.confirm({
      nzTitle: 'Are you sure to DELETE the selected task?',
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: async () => await this.deleteTask(taskId),
      nzCancelText: 'No',
      nzOnCancel: () => console.log('Cancel'),
    });
  }
}
