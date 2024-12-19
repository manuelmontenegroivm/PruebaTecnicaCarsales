import { Episodio } from '../episodio.model';
import { Info } from '../info.model';

export class TodosLosEpisodiosRespuesta {
  constructor() {
    this.info = new Info();
    this.results = new Array<Episodio>();
  }
  info: Info;
  results: Array<Episodio>;
}
