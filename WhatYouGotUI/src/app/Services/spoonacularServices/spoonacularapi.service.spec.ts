import { TestBed } from '@angular/core/testing';

import { SpoonacularapiService } from './spoonacularapi.service';

describe('SpoonacularapiService', () => {
  let service: SpoonacularapiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SpoonacularapiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
