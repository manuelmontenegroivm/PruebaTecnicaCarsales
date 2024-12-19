import { Component, OnInit } from '@angular/core';
import { SpinnerVisibilityService } from 'ng-http-loader';
import { Episodio } from 'src/app/models/episodio.model';
import { Personaje } from 'src/app/models/personaje.model';
import { TodosLosEpisodiosRespuesta } from 'src/app/models/respuestas/todos-los-episodios-respuesta';
import { EpisodioService } from 'src/app/services/episodio/episodio.service';
import { NotificacionesService } from 'src/app/services/notificaciones.service';
import { PersonajeService } from 'src/app/services/personaje/personaje.service';

@Component({
  selector: 'app-lista-paginado-episodio',
  templateUrl: './lista-paginado-episodio.component.html',
  styleUrls: ['./lista-paginado-episodio.component.css'],
})
export class ListaPaginadoEpisodioComponent implements OnInit {
  public episodiosPaginado: TodosLosEpisodiosRespuesta;
  public episodios: Array<Episodio>;
  public episodio: Episodio;
  public paginaActual: number = 1;

  public personajes: Array<Personaje>;
  public personaje: Personaje;

  public mostrar: boolean = true;

  constructor(
    private episodioService: EpisodioService,
    private notificacionesService: NotificacionesService,
    private spinner: SpinnerVisibilityService,
    private personajeService: PersonajeService
  ) {
    this.episodiosPaginado = new TodosLosEpisodiosRespuesta();
    this.episodios = new Array<Episodio>();
    this.episodio = new Episodio();
    this.personajes = new Array<Personaje>();
    this.personaje = new Personaje();
  }

  ngOnInit(): void {
    this.spinner.show();
    this.obtenerEpisodiosPaginados(this.paginaActual);
  }

  obtenerEpisodiosPaginados(pagina: number): void {
    this.spinner.show();
    this.personajes = new Array<Personaje>();
    this.personaje = new Personaje();
    this.episodio = new Episodio();
    this.episodioService
      .obtenerEpisodiosPaginados(pagina)
      .then((respuesta: TodosLosEpisodiosRespuesta) => {
        this.episodiosPaginado = respuesta;
        this.episodios = this.episodiosPaginado.results;
        this.mostrar = true;
        this.obtenerEpisodioPorId(this.episodios[0].id);
        this.spinner.hide();
      })
      .catch((e) => {
        this.mostrar = false;
        this.notificacionesService.mostrarMensaje(
          'error',
          'Error',
          'Ha ocurrido un error al obtener los episodios'
        );
        this.spinner.hide();
      });
  }

  obtenerEpisodioPorId(id: number): void {
    this.personajes = new Array<Personaje>();
    this.personaje = new Personaje();
    this.episodio = new Episodio();
    this.spinner.show();
    this.episodioService
      .obtenerEpisodioPorId(id)
      .then((episodio: Episodio) => {
        this.episodio = episodio;
        const idsPersonaje = new Array<number>();
        let contador = 0;
        let idPrimerPersonaje = 0;
        this.episodio.characters.forEach((x) => {
          if (contador === 0) {
            idPrimerPersonaje = Number(x.substring(x.lastIndexOf('/') + 1));
          }
          idsPersonaje.push(Number(x.substring(x.lastIndexOf('/') + 1)));
          contador++;
        });
        this.mostrar = true;
        this.obtenerMultiplesPersonajesPorId(idsPersonaje);
        this.obtenerPersonajePorId(idPrimerPersonaje);
        this.spinner.hide();
      })
      .catch((e) => {
        this.mostrar = false;
        this.notificacionesService.mostrarMensaje(
          'error',
          'Error',
          'Ha ocurrido un error al obtener episodio seleccionado'
        );
        this.spinner.hide();
      });
  }

  obtenerMultiplesPersonajesPorId(ids: Array<number>): void {
    this.personajeService
      .obtenerMultiplesPersonajes(ids)
      .then((characters: Array<Personaje>) => {
        this.personajes = characters;
        this.mostrar = true;
      })
      .catch((e) => {
        this.mostrar = false;
        this.notificacionesService.mostrarMensaje(
          'error',
          'Error',
          'Ha ocurrido un error al obtener personajes'
        );
        this.spinner.hide();
      });
  }

  obtenerPersonajePorId(id: number): void {
    this.personajeService
      .obtenerPersonajePorId(id)
      .then((character: Personaje) => {
        this.personaje = character;
        this.mostrar = true;
      })
      .catch((e) => {
        this.mostrar = false;
        this.notificacionesService.mostrarMensaje(
          'error',
          'Error',
          'Ha ocurrido un error al obtener personaje'
        );
        this.spinner.hide();
      });
  }

  cambiarPagina(direccion: string): void {
    if (direccion === 'izq') {
      if (this.paginaActual === 1) {
        this.notificacionesService.mostrarMensaje(
          'info',
          'Información',
          'Se encuentra en la primera página de los episodios'
        );
        return;
      } else {
        this.paginaActual -= 1;
      }
    } else if (direccion === 'der') {
      if (this.paginaActual === this.episodiosPaginado.info.pages) {
        this.notificacionesService.mostrarMensaje(
          'info',
          'Información',
          'Se encuentra en la última página de los episodios'
        );
        return;
      } else {
        this.paginaActual += 1;
      }
    }
    this.obtenerEpisodiosPaginados(this.paginaActual);
  }
}
