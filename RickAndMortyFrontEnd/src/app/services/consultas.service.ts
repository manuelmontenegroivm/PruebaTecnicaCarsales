import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Parametro } from '../models/parametro.model';
import { Parametros } from '../utils/parametro.utils';

@Injectable({
  providedIn: 'root',
})
export class ConsultasService {
  private readonly urlApi = environment.rutaApi;

  constructor(private http: HttpClient, private router: Router) {}

  public consultaObtenerAlgoDesconocido(
    algo: any,
    controlador: string,
    metodo: string,
    parametros: Array<Parametro>
  ): Observable<any> {
    return this.http.get<any>(
      `${this.urlApi}${controlador}${metodo}${Parametros.cadenaParametros(
        parametros
      )}`
    );
  }

  public consultaObtenerMultiplesAAlgoDesconocido(
    algo: any,
    controlador: string,
    metodo: string,
    parametros: HttpParams
  ): Observable<any> {
    return this.http.get<any>(`${this.urlApi}${controlador}${metodo}`, {
      params: parametros,
    });
  }
}
