import { Injectable } from '@angular/core';
import { Parametro } from 'src/app/models/parametro.model';
import { Personaje } from 'src/app/models/personaje.model';
import { ConsultasService } from '../consultas.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class PersonajeService {
  private readonly controlador = '/Character/';
  constructor(private consultaService: ConsultasService) {}

  public obtenerMultiplesPersonajes(
    ids: Array<number>
  ): Promise<Array<Personaje>> {
    const parametros = new Array<Parametro>();
    ids.forEach((x) => {
      parametros.push(new Parametro('ids', x));
    });

    const personajes = this.consultaService
      .consultaObtenerAlgoDesconocido(
        new Personaje(),
        this.controlador,
        'ObtenerMultiplesPersonajesPorId',
        parametros
      )
      .pipe(
        map((res) => {
          return res;
        })
      )
      .toPromise();
    return personajes;
  }

  public obtenerPersonajePorId(id: number): Promise<Personaje> {
    const parametros = new Array<Parametro>();
    parametros.push(new Parametro('id', id));
    const personaje = this.consultaService
      .consultaObtenerAlgoDesconocido(
        new Personaje(),
        this.controlador,
        'ObtenerPersonajePorId',
        parametros
      )
      .pipe(
        map((res) => {
          return res;
        })
      )
      .toPromise();
    return personaje;
  }
}
