import { TestBed } from '@angular/core/testing';

import { AuthGuardService } from './activegaurd.service';

describe('ActivegaurdService', () => {
  let service: AuthGuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthGuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
