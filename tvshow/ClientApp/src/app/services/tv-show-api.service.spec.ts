import { TestBed } from '@angular/core/testing';

import { TvShowApiService } from './tv-show-api.service';

describe('TvShowApiService', () => {
  let service: TvShowApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TvShowApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
