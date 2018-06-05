import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MarkettingFeatureComponent } from './marketting-feature.component';

describe('MarkettingFeatureComponent', () => {
  let component: MarkettingFeatureComponent;
  let fixture: ComponentFixture<MarkettingFeatureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MarkettingFeatureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MarkettingFeatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
