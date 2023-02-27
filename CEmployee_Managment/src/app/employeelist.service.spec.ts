import { TestBed } from '@angular/core/testing';

import { EmployeelistService } from './employeelist.service';

describe('EmployeelistService', () => {
  let service: EmployeelistService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployeelistService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
