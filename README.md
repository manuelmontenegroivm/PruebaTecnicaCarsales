# Ejecución del Frontend

Este proyecto está desarrollado en Angular y consume una API del backend para mostrar información relacionada con la serie Rick and Morty. A continuación se detallan los pasos para ejecutar el proyecto.

# Instrucciones de Ejecución

## Paso 1: Instalar Dependencias

Abre una consola en el directorio del proyecto front/rick-y-morty y ejecuta el siguiente comando para instalar todas las dependencias necesarias:

### `npm install`

## Paso 2: Configuración de Node (si es necesario)

Si encuentras problemas relacionados con OpenSSL, como errores en el proceso de compilación, puedes configurar Node.js para usar el proveedor heredado de OpenSSL ejecutando:

### `set NODE_OPTIONS=--openssl-legacy-provider`

Este paso es necesario en algunas versiones de Node.js, especialmente si estás utilizando versiones más nuevas que presentan problemas de compatibilidad con OpenSSL.

## Paso 3: Levantar el Servidor de Desarrollo

Una vez instaladas las dependencias y configurado el entorno de Node (si es necesario), ejecuta el siguiente comando para iniciar el servidor de desarrollo:

### `ng serve`

Este comando iniciará una instancia local de la aplicación en el puerto 4200. Además, debería abrir automáticamente una ventana o pestaña del navegador. Si no es así, puedes acceder manualmente utilizando la siguiente URL:

[http://localhost:4200](http://localhost:4200)

## Navegación

Una vez que el servidor esté corriendo, puedes navegar por el sitio para visualizar el funcionamiento del proyecto. Podrás ver las páginas interactivas que consumen la API de Rick and Morty y visualizar la información correspondiente.

¡Listo! Ahora puedes explorar el proyecto y verificar que todo esté funcionando correctamente.

Este formato es directo y conciso, proporcionando solo la información necesaria para ejecutar el proyecto.

# Ejecución del Backend

Este proyecto está basado en una aplicación ASP.NET Core Web API que sigue la arquitectura Backend for Frontend (BFF). Este enfoque ha sido implementado para actuar como intermediario entre el frontend y la API externa de Rick and Morty, proporcionando datos de manera optimizada y específica para las necesidades del frontend.

La arquitectura del backend hace uso de inyección de dependencias para garantizar una integración flexible y escalable con la API externa, permitiendo realizar llamadas a la API de Rick and Morty a través de métodos bien definidos y controlados.

## Instrucciones para Ejecutar el Proyecto

Sigue estos pasos para ejecutar el proyecto en tu entorno local:

### 1. Abrir la Solución

Al abrir la solución en Visual Studio, asegúrate de que el archivo Backend.sln esté seleccionado y listo para ejecutarse.

### 2. Iniciar la Aplicación

Presiona F5 o selecciona "Iniciar depuración" en Visual Studio para levantar el servidor de la API. Esto iniciará la aplicación en un servidor local y abrirá automáticamente una ventana del navegador.

### 3. Acceder a Swagger

Una vez que la API esté en funcionamiento, el navegador debería abrirse con la interfaz de Swagger, que te permitirá ver todos los puntos finales disponibles para interactuar con la API. Swagger también te permitirá realizar pruebas directamente desde el navegador.

### 4. Realizar Pruebas

Puedes realizar pruebas de los diferentes endpoints utilizando Swagger o herramientas como Postman. Si prefieres usar Postman, puedes importar la siguiente colección para acceder a los endpoints de manera sencilla:

# Endpoints Disponibles

Los siguientes endpoints están disponibles en la API:

GET /api/episodes: Obtiene una lista de episodios de Rick and Morty.
GET /api/characters: Obtiene una lista de personajes.
GET /api/locations: Obtiene una lista de localizaciones.
Estos endpoints proporcionan datos en formato JSON y pueden ser utilizados para interactuar con el frontend de la aplicación.

# Configuración del Entorno

Este proyecto requiere que tu entorno de desarrollo esté configurado con .NET Core y las dependencias necesarias para realizar peticiones HTTP. Asegúrate de tener los siguientes paquetes instalados:

Microsoft.AspNetCore.Mvc
Newtonsoft.Json
Swashbuckle.AspNetCore (para Swagger)

1. Restaurar las Dependencias
   Una vez que hayas clonado el repositorio, abre una terminal en el directorio del proyecto y ejecuta:

### dotnet restore 2. Ejecutar el Proyecto

Para ejecutar el proyecto desde la línea de comandos, utiliza el siguiente comando:

### dotnet run

El servidor se iniciará en el puerto configurado (por defecto, http://localhost:5000).
