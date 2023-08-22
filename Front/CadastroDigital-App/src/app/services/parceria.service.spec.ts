/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ParceriaService } from './parceria.service';

describe('Service: Parceria', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ParceriaService]
    });
  });

  it('should ...', inject([ParceriaService], (service: ParceriaService) => {
    expect(service).toBeTruthy();
  }));
});
