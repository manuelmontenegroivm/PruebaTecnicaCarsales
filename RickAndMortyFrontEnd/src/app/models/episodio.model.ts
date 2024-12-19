import { RickYMorty } from './rick-y-morty.models';

export class Episodio extends RickYMorty {
  constructor() {
    super();
    this.air_Date = '';
    this.episode = '';
    this.characters = new Array<string>();
  }
  tipoCaptura: string = 'Episodio';
  air_Date: string;
  episode: string;
  characters: Array<string>;
}
