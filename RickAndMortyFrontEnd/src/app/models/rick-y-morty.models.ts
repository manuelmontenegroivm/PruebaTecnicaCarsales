export abstract class RickYMorty {
  constructor() {
    this.id = 0;
    this.name = '';
    this.type = '';
    this.url = '';
    this.created = new Date();
  }
  id: number;
  name: string;
  type: string;
  url: string;
  created: Date;
  abstract tipoCaptura: string;
}
