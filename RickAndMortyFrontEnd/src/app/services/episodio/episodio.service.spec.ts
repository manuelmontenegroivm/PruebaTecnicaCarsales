import { TestBed } from '@angular/core/testing';

import { EpisodioService } from './episodio.service';

describe('EpisodioService', () => {
  let service: EpisodioService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EpisodioService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
