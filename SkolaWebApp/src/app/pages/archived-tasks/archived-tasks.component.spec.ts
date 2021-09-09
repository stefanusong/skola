import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArchivedTasksComponent } from './archived-tasks.component';

describe('ArchivedTasksComponent', () => {
  let component: ArchivedTasksComponent;
  let fixture: ComponentFixture<ArchivedTasksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArchivedTasksComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ArchivedTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
