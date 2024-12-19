import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Parametro } from 'src/app/models/parametro.model';
import { TodosLosEpisodiosRespuesta } from 'src/app/models/respuestas/todos-los-episodios-respuesta';
import { ConsultasService } from '../consultas.service';
import { map } from 'rxjs/operators';
import { relativeTimeRounding } from 'moment';
import { Episodio } from 'src/app/models/episodio.model';

@Injectable({
  providedIn: 'root',
})
export class EpisodioService {
  private readonly controlador = '/EpisodeControler/';
  constructor(private consultaService: ConsultasService) {}

  public obtenerEpisodiosPaginados(
    pagina: number = 1
  ): Promise<TodosLosEpisodiosRespuesta> {
    const parametros = new Array<Parametro>();
    parametros.push(new Parametro('pagina', pagina));
    const episodios = this.consultaService
      .consultaObtenerAlgoDesconocido(
        new TodosLosEpisodiosRespuesta(),
        this.controlador,
        'ObtenerEpisodiosPaginado',
        parametros
      )
      .pipe(
        map((res) => {
          return res;
        })
      )
      .toPromise();
    return episodios;
  }

  public obtenerEpisodioPorId(id: number = 1): Promise<Episodio> {
    const parametros = new Array<Parametro>();
    parametros.push(new Parametro('id', id));
    const episodios = this.consultaService
      .consultaObtenerAlgoDesconocido(
        new TodosLosEpisodiosRespuesta(),
        this.controlador,
        'ObtenerEpisodioPorId',
        parametros
      )
      .pipe(
        map((res) => {
          return res;
        })
      )
      .toPromise();
    return episodios;
  }
}
