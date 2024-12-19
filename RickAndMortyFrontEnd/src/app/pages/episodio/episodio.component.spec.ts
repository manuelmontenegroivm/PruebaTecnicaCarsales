import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EpisodioComponent } from './episodio.component';

describe('EpisodioComponent', () => {
  let component: EpisodioComponent;
  let fixture: ComponentFixture<EpisodioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EpisodioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EpisodioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
