/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PessoafisicaService } from './pessoafisica.service';

describe('Service: Pessoafisica', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PessoafisicaService]
    });
  });

  it('should ...', inject([PessoafisicaService], (service: PessoafisicaService) => {
    expect(service).toBeTruthy();
  }));
});
