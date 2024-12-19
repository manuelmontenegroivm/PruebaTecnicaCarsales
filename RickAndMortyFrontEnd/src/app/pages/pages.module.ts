import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EpisodioComponent } from './episodio/episodio.component';
import { PagesComponent } from './pages.component';
import { PagesRoutingModule } from './pages-routing.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [PagesComponent, EpisodioComponent],
  imports: [CommonModule, PagesRoutingModule, ReactiveFormsModule],
})
export class PagesModule {}
