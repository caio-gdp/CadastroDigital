/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EstadoCivilService } from './estadocivil.service';

describe('Service: Estadocivil', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EstadoCivilService]
    });
  });

  it('should ...', inject([EstadoCivilService], (service: EstadoCivilService) => {
    expect(service).toBeTruthy();
  }));
});
