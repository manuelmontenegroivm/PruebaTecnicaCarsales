import { Parametro } from '../models/parametro.model';

const cadenaParametros = (parametros: Array<Parametro>): string => {
  let cadena = '';
  let i = 0;
  parametros.forEach((x) => {
    // debugger;
    if (i == 0) {
      cadena = `?${x.nombreParametro}=${x.valorParametro}`;
    } else {
      cadena += `&${x.nombreParametro}=${x.valorParametro}`;
    }
    i++;
  });
  return cadena;
};

export const Parametros = {
  cadenaParametros,
};
