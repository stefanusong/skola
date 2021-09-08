import { Component, OnInit } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { CreateTaskDto, EditTaskDto } from 'src/app/dto/dto';
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
    private taskService: TaskService,
    private modal: NzModalService
  ) {}

  ngOnInit(): void {
    var selectedSubject = this.subjectService.getSelectedSubject();
    this.subjectId = selectedSubject.subjectId;
    this.subjectName = selectedSubject.subjectName;

    this.getTasks();
  }

  subjectId = '';
  subjectName = '';
  // listOfTasks: any[] = [{ taskName: 'wkwkwkwkwkwkwkwkk', isCompleted: true }];
  listOfTasks: any[] = [];
  newTaskName = '';
  updatedTaskDto: EditTaskDto = { taskId: '', taskName: '' };
  isCreatingTask = false;
  isUpdatingTask = false;
  isVisibleAddTask = false;
  isVisibleEditTask = false;

  //API CALLS
  getTasks() {
    this.taskService.getTasksBySubject(this.subjectId).subscribe((resp) => {
      if (resp) {
        this.listOfTasks = resp;
        this.isCreatingTask = false;
        this.isVisibleAddTask = false;
        this.isUpdatingTask = false;
        this.isVisibleEditTask = false;
      }
    });
  }

  createTask() {
    const newTask: CreateTaskDto = {
      subjectId: this.subjectId,
      taskName: this.newTaskName,
    };

    this.taskService.createNewTask(newTask).subscribe((resp) => {
      if (resp) {
        this.getTasks();
      }
    });
  }

  setTaskComplete(taskId: string) {
    this.taskService.setTaskCompleteStatus(taskId).subscribe((resp) => {
      if (resp == true) {
        this.getTasks();
      }
    });
  }

  deleteTask(taskId: string) {
    this.taskService.deleteTask(taskId).subscribe((resp) => {
      if (resp == true) {
        this.getTasks();
      }
    });
  }

  archiveTask(taskId: string) {
    this.taskService.archiveTask(taskId).subscribe((resp) => {
      if (resp == true) {
        this.getTasks();
      }
    });
  }

  editTask() {
    this.taskService.editTask(this.updatedTaskDto).subscribe((resp) => {
      if (resp) {
        this.getTasks();
      }
    });
  }

  // Add task modal
  showAddTaskModal() {
    this.isVisibleAddTask = true;
  }

  handleCancelAddTask() {
    this.isVisibleAddTask = false;
  }

  handleOkAddTask() {
    this.isCreatingTask = true;
    this.createTask();
  }

  //Delete task mdoal
  showDeleteTaskModal(taskId: string) {
    this.modal.confirm({
      nzTitle: 'Are you sure to delete the selected task?',
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: async () => await this.deleteTask(taskId),
      nzCancelText: 'No',
      nzOnCancel: () => console.log('Cancel'),
    });
  }

  //Archive task modal
  showArchiveTaskModal(taskId: string) {
    this.modal.confirm({
      nzTitle: 'Are you sure to archive the selected task?',
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: async () => await this.archiveTask(taskId),
      nzCancelText: 'No',
      nzOnCancel: () => console.log('Cancel'),
    });
  }

  //Edit task modal
  showEditTaskModal(taskId: string, taskName: string) {
    this.updatedTaskDto.taskName = taskName;
    this.updatedTaskDto.taskId = taskId;
    this.isVisibleEditTask = true;
  }

  handleCancelEditTask() {
    this.isVisibleEditTask = false;
  }

  handleOkEditTask() {
    this.isUpdatingTask = true;
    this.editTask();
  }
}
