/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AgregateComponent } from './agregate.component';

describe('AgregateComponent', () => {
  let component: AgregateComponent;
  let fixture: ComponentFixture<AgregateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgregateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
