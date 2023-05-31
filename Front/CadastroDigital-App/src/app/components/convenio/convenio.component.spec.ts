/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ConvenioComponent } from './convenio.component';

describe('ConvenioComponent', () => {
  let component: ConvenioComponent;
  let fixture: ComponentFixture<ConvenioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConvenioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConvenioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
