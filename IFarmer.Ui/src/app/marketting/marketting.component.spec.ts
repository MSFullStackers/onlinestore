import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MarkettingComponent } from './marketting.component';

describe('MarkettingComponent', () => {
  let component: MarkettingComponent;
  let fixture: ComponentFixture<MarkettingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MarkettingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MarkettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
