/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PaisService } from './Pais.service';

describe('Service: Pais', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PaisService]
    });
  });

  it('should ...', inject([PaisService], (service: PaisService) => {
    expect(service).toBeTruthy();
  }));
});
