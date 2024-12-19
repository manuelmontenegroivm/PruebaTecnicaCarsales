import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { ListaPaginadoEpisodioComponent } from './lista-paginado-episodio/lista-paginado-episodio.component';

const routes: Routes = [
  {
    path: '',
    component: ListaPaginadoEpisodioComponent,
  },
];

@NgModule({
  declarations: [ListaPaginadoEpisodioComponent],
  imports: [CommonModule, RouterModule.forChild(routes), ReactiveFormsModule],
  exports: [ListaPaginadoEpisodioComponent],
})
export class EpisodioModule {}
