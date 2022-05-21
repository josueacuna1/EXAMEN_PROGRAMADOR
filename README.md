# EXAMEN PROGRAMADOR

### Objetivo
> El aspirante a la vacante de programador deberá demostrar sus conocimientos técnicos
creando una aplicación web, en donde se evaluará el dominio de esta tecnología y la
arquitectura utilizada.arquitectura utilizada.

### Desarrollo
#### Base de datosbase de datos
> Para la parte de base de datos se optó por utilizar como entono a Microsoft Sql Server Management Studio 18.

Lo primero que se hizo fue crear la base de datos, y crear las tablas que contendrían la información, se crearon 3 tablas, una de ellas almacenaría la información de los clientes, otra almacenaría los tipos de cuentas disponibles y la última almacenaría las cuentas ligadas a un usuario.

Una vez creadas las tablas se crearon los Procedimientos almacenados (SP) que harían las consultas, actualizaciones y eliminaciones correspondientes; se crearon en total 4, el primero obtiene la información del cliente, el segundo obtiene la información de las cuentas ligadas con un cliente, la tercera actualiza la información del cliente y la última elimina del sistema al cliente.

> [![1bd.jpg](https://i.postimg.cc/br8yHxr8/1bd.jpg)](https://postimg.cc/hzyRK7V3)
> 
>Base de datos y procedimientos almacenados 

Por último solo queda hacer unas inserciones y verificar que se inserten los datos correctamente.

>[![2bd.jpg](https://i.postimg.cc/Lsbv1DyY/2bd.jpg)](https://postimg.cc/sB5pFYCs)
>
>Inserción exitosa

#### ***Backend (API)***
Se creó un proyecto utilizando ASP .Net (framework) configurándola para que sea una API web. Lo primero que se originó fue el modelo con el que íbamos a estar trabajando, primero se creó el modelo correspondiente al cliente y posterior a ello el modelo correspondiente a las cuentas ligadas a un cliente.
Lo siguiente fue generar una carpeta llamada Data en donde se almacenó la conexión con la BD y una clase en donde agregamos los métodos para que realizara las ejecuciones de los SP necesarios.
Por último creamos un controlador que llamara a los métodos correspondientes gracias a las peticiones que la aplicación haga, ya sean Get(), Put() y Delete().

> [![1b.jpg](https://i.postimg.cc/gkzRGRDf/1b.jpg)](https://postimg.cc/0r4rfzhf)
Carpetas del proyecto.

Una vez teniendo la API procedemos a ejecutarla y verificar que este todo correcto.
> [![2b.jpg](https://i.postimg.cc/vZRsW7NK/2b.jpg)](https://postimg.cc/1fK2SFP0)
>
>API ejecutándose exitosamente.

Para verificar que funcione la API podemos consumirla utilizando Postman, en mi caso fue así, le pase la ruta del localhost que me regreso la API y le agregue el controlador y en mi caso si no le paso ningún parámetro me devuelve la información de los clientes dados de alta.

> [![3b.jpg](https://i.postimg.cc/sxvMZPNX/3b.jpg)](https://postimg.cc/0K1kTSxR)
>
>Ejecución exitosa.

Con postman se verificó el funcionamiento de la API y de los sp que se crearon en un inicio.

#### ***Frontend***
>Para la parte de frontend se manejaron las tecnologías clásicas de la web, además se incluirá bootstrap para la parte del diseño y para manejar el llamado a la API se utilizan peticiones ajax, por lo tanto, se utilizará Jquery.

Lo primero que se hizo fue estructurar el proyecto, primero se crearon las carpetas correspondientes para el CSS, JS y la carpeta que contendría las imágenes, además se agregaron dos archivos de HTML, uno será el index y el otro será para ver las cuentas activas de los clientes.

> [![f1.jpg](https://i.postimg.cc/tJshHnWK/f1.jpg)](https://postimg.cc/K3yKPz9f)
>
>Estructura del front.

Posterior a ello desarrollamos toda la interfaz y el manejo de la información al llamar a la API, creamos los funciones necesarios, las peticiones necesarios, así como algunas pocas validaciones y la aparición de alertas en caso de que ocurra algo importante.



https://user-images.githubusercontent.com/90817374/169666833-7921bd90-525f-4ee2-a32b-a55c90e7c855.mp4

