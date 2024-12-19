import { Location } from './location.model';
import { Origin } from './origin.model';
import { RickYMorty } from './rick-y-morty.models';

export class Personaje extends RickYMorty {
  constructor() {
    super();
    this.status = '';
    this.gender = '';
    this.origin = new Origin();
    this.location = new Location();
    this.image = '';
    this.episode = new Array<string>();
  }
  tipoCaptura: string = 'Personaje';
  status: string;
  gender: string;
  origin: Origin;
  location: Location;
  image: string;
  episode: Array<string>;
}
