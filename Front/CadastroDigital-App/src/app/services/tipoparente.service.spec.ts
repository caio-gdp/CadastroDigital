/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TipoParenteService } from './tipoparente.service';

describe('Service: Tipoparente', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TipoParenteService]
    });
  });

  it('should ...', inject([TipoParenteService], (service: TipoParenteService) => {
    expect(service).toBeTruthy();
  }));
});
