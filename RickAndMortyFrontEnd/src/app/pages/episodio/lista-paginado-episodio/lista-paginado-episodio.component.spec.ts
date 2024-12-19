import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaPaginadoEpisodioComponent } from './lista-paginado-episodio.component';

describe('ListaPaginadoEpisodioComponent', () => {
  let component: ListaPaginadoEpisodioComponent;
  let fixture: ComponentFixture<ListaPaginadoEpisodioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaPaginadoEpisodioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaPaginadoEpisodioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
