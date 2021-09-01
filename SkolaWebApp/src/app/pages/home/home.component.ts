import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(private authService: AuthService) {}

  name: string = '';

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
}
