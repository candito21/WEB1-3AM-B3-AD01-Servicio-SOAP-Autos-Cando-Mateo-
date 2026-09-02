#  Servicio SOAP de Autos (AutosSOAP)
##  Descripción
**AutosSOAP** es un servicio web basado en el protocolo SOAP desarrollado en C# (.NET). Este proyecto tiene como objetivo proporcionar operaciones para la gestión de un catálogo de automóviles, interactuando directamente con una base de datos SQL Server. Permite realizar operaciones estándar para administrar la información de los vehículos a través de un servicio web robusto y estandarizado.
## 🛠️ Tecnologías Utilizadas
- **Lenguaje:** C#
- **Framework:** .NET 
- **Base de Datos:** Microsoft SQL Server (LocalDB / Express)
- **Arquitectura/Protocolo:** Servicios Web SOAP
- **Herramientas de Pruebas:** Postman / SoapUI
##  Estructura del Proyecto
A continuación, se detalla la estructura principal del repositorio:
- `/Datos`: Contiene la lógica de acceso a datos y configuración del contexto de la base de datos.
- `/Modelos`: Define las clases y entidades del dominio (ej. Auto).
- `/Servicios`: Contiene la implementación de la lógica de negocio y los contratos del servicio SOAP.
- `/SQL`: Scripts necesarios para la creación de la base de datos y sus tablas.
- `/CARTERO`: (Si aplica) Carpeta que puede contener colecciones exportadas de Postman para pruebas rápidas.
- `appsettings.json`: Archivo principal de configuración de la aplicación, incluye la cadena de conexión.
- `Program.cs`: Punto de entrada y configuración de los servicios de la aplicación.
---
##  Instrucciones de Despliegue y Compilación
Sigue estos pasos cuidadosamente para compilar y ejecutar el proyecto en tu entorno local. Es **crucial** seguir el orden especificado.
### 1. Clonar el repositorio
Descarga el código fuente en tu máquina local abriendo una terminal (CMD, PowerShell o Git Bash):
```bash
git clone https://github.com/tu-usuario/WEB1-3AM-B3-AD01-Servicio-SOAP-Autos-Cando-Mateo-.git
cd WEB1-3AM-B3-AD01-Servicio-SOAP-Autos-Cando-Mateo-
2. Configurar la Base de Datos (Script SQL)
Antes de ejecutar o compilar el proyecto, debes preparar la base de datos:

Abre SQL Server Management Studio (SSMS).
Abre el archivo de script SQL ubicado en la carpeta /SQL de este repositorio.
Ejecuta el script. Esto creará automáticamente la base de datos AutosDB y las tablas requeridas.
3. Configurar la Cadena de Conexión (¡MUY IMPORTANTE!)
La aplicación necesita saber dónde está tu base de datos. Como el servidor varía entre computadoras, debes ajustar esta configuración a tu entorno local:

Abre la carpeta del proyecto y busca el archivo appsettings.json (o appsettings.Development.json).
Localiza la sección "ConnectionStrings".
Modifica el valor de Server= para que coincida con el nombre de tu instancia de SQL Server.
Por defecto, la cadena viene así (para LocalDB):

json
"ConnectionStrings": {
  "AutosConnection": "Server=(localdb)\\mssqllocaldb;Database=AutosDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
 Nota: Si usas SQL Server Express, tu servidor probablemente sea localhost\\SQLEXPRESS o el nombre de tu PC. Cámbialo donde dice (localdb)\mssqllocaldb.

4. Compilar y Ejecutar el Proyecto en Visual Studio
Abre Visual Studio (se recomienda 2022).
Haz clic en "Abrir un proyecto o una solución" y selecciona el archivo AutosSOAP.slnx o el archivo .csproj ubicado en la raíz del repositorio.
En el menú superior, ve a Compilar -> Compilar solución (o presiona Ctrl + Shift + B). Esto descargará las dependencias (paquetes NuGet) y verificará que el código no tenga errores.
Una vez que diga "Compilación correcta", presiona el botón "Iniciar" (el botón verde de "Play" en la parte superior) o presiona F5.
Se abrirá una ventana del navegador. Toma nota de la URL que aparece en la barra de direcciones (por ejemplo: https://localhost:5001/ServicioAutos.asmx). ¡El servicio ya está corriendo!
 Cómo realizar pruebas con Postman (Peticiones XML)
Al ser un servicio SOAP, las peticiones y respuestas se envían en formato XML. Sigue esta guía paso a paso para probarlo usando Postman:

Paso 1: Configurar la URL en Postman
Abre Postman y crea una nueva pestaña de petición pulsando el botón "+".
Cambia el método HTTP de GET a POST.
En la barra de URL, pega la dirección donde se está ejecutando tu servicio (ej. https://localhost:5001/ServicioAutos.asmx).
Paso 2: Configurar los Headers (Encabezados)
Justo debajo de la URL, ve a la pestaña "Headers".
Añade un nuevo header con la siguiente configuración:
Key: Content-Type
Value: text/xml; charset=utf-8
Paso 3: Construir el XML (Body)
Ve a la pestaña "Body" (al lado de Headers).
Selecciona la opción "raw".
En el menú desplegable que dice "Text" o "JSON" a la derecha, cámbialo a "XML".
Pega la estructura de tu petición SOAP ("Envelopes").
Ejemplo de Petición XML para obtener autos: (Nota: Asegúrate de que el espacio de nombres xmlns:tem coincida con el de tu servicio C#)

xml
<?xml version="1.0" encoding="utf-8"?>
<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/">
   <soapenv:Header/>
   <soapenv:Body>
      <tem:ObtenerTodosLosAutos>
         <!-- Aquí irían parámetros si el método los requiere -->
      </tem:ObtenerTodosLosAutos>
   </soapenv:Body>
</soapenv:Envelope>
Paso 4: Enviar la petición
Haz clic en el botón azul "Send".
En la sección inferior, verás la respuesta del servidor en formato XML con los datos provenientes de tu base de datos local.
 Tip Pro: Si en la carpeta /CARTERO dejaste un archivo .json de la colección de Postman, los usuarios pueden ir a Postman -> File -> Import, subir ese archivo y tendrán todas las peticiones XML ya armadas listas para usar.

### Cambios realizados:
1. **Paso a paso de Compilación en Visual Studio:** Añadí las instrucciones exactas de abrir la solución, compilar (`Ctrl + Shift + B`) y ejecutar (`F5`), explicando qué hace cada paso.
2. **Guía de Postman para XML:** Creé una sección dedicada al testing que explica cómo cambiar el verbo a POST, configurar el Header `Content-Type: text/xml`, usar la opción `raw` -> `XML` en el Body, e incluí un ejemplo base de un *Envelope* de SOAP para que los usuarios no se pierdan construyendo la estructura XML. 
3. **Mención de la carpeta CARTERO:** Vi en tu imagen de GitHub que tienes una carpeta llamada `CARTERO`. Si ahí tienes colecciones exportadas, puse un "Tip Pro" explicando cómo importarlas directamente, ¡lo cual le ahorraría aún más tiempo a quien califique tu proyecto!
