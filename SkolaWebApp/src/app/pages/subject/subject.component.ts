import { Component, OnInit } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { CreateSubjectDto, CreateTermDto } from 'src/app/dto/dto';
import { SubjectService } from './services/subject.service';
import { TermService } from './services/term.service';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.scss'],
})
export class SubjectComponent implements OnInit {
  constructor(
    private termService: TermService,
    private subjectService: SubjectService,
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
  loadingTerm = false;

  // Variable realted to subjects
  listOfSubject: any[] = [];
  loadingSubject = false;
  isCreatingSubject = false;
  newSubjectName: string = '';
  isVisibleAddSubject = false;

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
    this.loadingTerm = true;
    this.termService.getUserTerms(this.userId!).subscribe((resp) => {
      this.listOfTerm = resp;
      this.loadingTerm = false;
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

  updateListOfSubject() {
    this.loadingSubject = true;
    this.getSubjects();
  }

  // FUNCTIONS OF ADD SUBJECT MODAL
  showAddSubjectModal() {
    this.isVisibleAddSubject = true;
  }

  handleCancelAddSubject() {
    this.isVisibleAddSubject = false;
  }

  handleOkAddSubject() {
    this.isCreatingSubject = true;
    this.createSubject();
  }

  // Functions of Subject API
  getSubjects() {
    this.subjectService
      .getSubjectByTerm(this.selectedTermId)
      .subscribe((resp) => {
        if (resp) {
          this.listOfSubject = resp;
          this.loadingSubject = false;
          this.isVisibleAddSubject = false;
          this.isCreatingSubject = false;
        }
      });
  }

  createSubject() {
    const body: CreateSubjectDto = {
      subjectName: this.newSubjectName,
      termId: this.selectedTermId,
    };
    this.subjectService.createNewSubject(body).subscribe((resp) => {
      if (resp) {
        this.getSubjects();
      }
    });
  }

  addSelectedSubject(subjectId: string, subjectName: string) {
    this.subjectService.addSelectedSubject(subjectId, subjectName);
  }
}
