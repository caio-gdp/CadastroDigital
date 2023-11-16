/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DiretoriaService } from './diretoria.service';

describe('Service: Diretor', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DiretoriaService]
    });
  });

  it('should ...', inject([DiretoriaService], (service: DiretoriaService) => {
    expect(service).toBeTruthy();
  }));
});
