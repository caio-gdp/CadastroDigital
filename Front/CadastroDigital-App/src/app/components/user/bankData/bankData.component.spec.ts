/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BankDataComponent } from './bankData.component';

describe('BankDataComponent', () => {
  let component: BankDataComponent;
  let fixture: ComponentFixture<BankDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BankDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BankDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
