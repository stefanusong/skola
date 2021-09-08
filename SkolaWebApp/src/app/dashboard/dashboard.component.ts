import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  constructor(private authService: AuthService) {}
  isCollapsed = false;
  ngOnInit(): void {
    if (!localStorage.getItem('userid'))
      this.authService
        .getUserDetail(localStorage.getItem('email')!)
        .subscribe((resp) => {
          this.name = resp.fullName!;
          localStorage.setItem('fullname', resp.fullName);
          localStorage.setItem('userid', resp.id);
        });
    this.name = localStorage.getItem('fullname')!;
  }

  name = '';

  signOut() {
    localStorage.clear();
  }
}
