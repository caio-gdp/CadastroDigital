/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TipoRedeSocialService } from './tiporedesocial.service';

describe('Service: Tiporedesocial', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TipoRedeSocialService]
    });
  });

  it('should ...', inject([TipoRedeSocialService], (service: TipoRedeSocialService) => {
    expect(service).toBeTruthy();
  }));
});
