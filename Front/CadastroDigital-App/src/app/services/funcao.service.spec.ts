/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { FuncaoService } from './funcao.service';

describe('Service: Funcao', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FuncaoService]
    });
  });

  it('should ...', inject([FuncaoService], (service: FuncaoService) => {
    expect(service).toBeTruthy();
  }));
});
