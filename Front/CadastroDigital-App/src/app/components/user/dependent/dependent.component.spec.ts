/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DependentComponent } from './dependentcomponent';

describe('DependentagregateComponent', () => {
  let component: DependentComponent;
  let fixture: ComponentFixture<DependentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DependentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DependentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
