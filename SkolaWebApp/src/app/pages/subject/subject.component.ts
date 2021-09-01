import { Component, OnInit } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { CreateTermDto } from 'src/app/dto/dto';
import { TermService } from './services/term.service';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.scss'],
})
export class SubjectComponent implements OnInit {
  constructor(
    private termService: TermService,
    private modal: NzModalService
  ) {}

  ngOnInit(): void {
    this.getTerms();
  }
  // Variable related to user
  userId = localStorage.getItem('userid');

  // Variable related to Terms
  listOfTerm!: any[];
  department = ['Primary', 'Secondary', 'Junior College'];
  isVisibleAddTerm = false;
  newGrade = 1;
  newDept = 0;
  tempDepartment = this.department[this.newGrade - 1];
  isCreatingTerm = false;
  selectedTermId: string = '';

  // FUNCTIONS OF ADD TERM MODAL
  showAddTermModal() {
    this.newGrade = 1;
    this.isVisibleAddTerm = true;
  }

  handleCancelAddTerm() {
    this.isVisibleAddTerm = false;
  }

  handleOkAddTerm() {
    this.isCreatingTerm = true;
    this.createTerm(this.newGrade, this.newDept);
  }

  updateTempDepartment(event: any) {
    if (event <= 6) this.newDept = 0;
    else if (event <= 9) this.newDept = 1;
    else this.newDept = 2;
    this.tempDepartment = this.department[this.newDept];
  }

  // FUNCTIONS OF DELETE TERM MODAL
  showDeleteTermModal() {
    this.modal.confirm({
      nzTitle: 'Are you sure delete this selected term?',
      nzContent: '<b style="color: red;">Some descriptions</b>',
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: async () => await this.deleteTerm(),
      nzCancelText: 'No',
      nzOnCancel: () => console.log('Cancel'),
    });
  }
  // FUNCTIONS OF TERM API
  getTerms() {
    this.termService.getUserTerms(this.userId!).subscribe((resp) => {
      console.log(resp);
      this.listOfTerm = resp;
    });
  }

  createTerm(grade: number, department: number) {
    const body: CreateTermDto = {
      userId: this.userId!,
      grade: grade,
      department: department,
    };
    this.termService.createNewTerm(body).subscribe((resp) => {
      if (resp == null) {
        alert('Failed to add new term');
      } else {
        this.getTerms();
        this.isVisibleAddTerm = false;
        this.isCreatingTerm = false;
      }
    });
  }

  deleteTerm() {
    this.termService.deleteTerm(this.selectedTermId).subscribe((resp) => {
      if (resp) {
        window.location.reload();
      }
    });
  }
}
