#  Servicio SOAP de Autos (AutosSOAP)
##  Descripción
**AutosSOAP** es un servicio web basado en el protocolo SOAP desarrollado en C# (.NET). Este proyecto tiene como objetivo proporcionar operaciones para la gestión de un catálogo de automóviles, interactuando directamente con una base de datos SQL Server. Permite realizar operaciones estándar para administrar la información de los vehículos a través de un servicio web robusto y estandarizado, procesando peticiones en formato XML.
##  Tecnologías Utilizadas
- **Lenguaje:** C#
- **Framework:** .NET 
- **Base de Datos:** Microsoft SQL Server (LocalDB / Express)
- **Arquitectura/Protocolo:** Servicios Web SOAP
- **Herramientas de Pruebas:** Postman (mediante colección exportada)
##  Estructura del Proyecto
A continuación, se detalla la estructura principal del repositorio:
- `/Datos`: Contiene la lógica de acceso a datos y configuración del contexto de la base de datos.
- `/Modelos`: Define las clases y entidades del dominio (ej. Auto, Categoria).
- `/Servicios`: Contiene la implementación de la lógica de negocio y los contratos del servicio SOAP.
- `/SQL`: Scripts necesarios para la creación de la base de datos y sus tablas.
- `/CARTERO`: Contiene la colección exportada de Postman con todas las peticiones (XML) listas para ser ejecutadas.
- `appsettings.json`: Archivo principal de configuración de la aplicación, incluye la cadena de conexión.
- `Program.cs`: Punto de entrada y configuración de los servicios de la aplicación.
- `AutosSOAP.slnx` / `.csproj`: Archivos de solución y proyecto para abrir en Visual Studio.
---
##  Instrucciones de Despliegue, Compilación y Ejecución
Sigue estos pasos cuidadosamente y en este orden exacto para garantizar que el proyecto se ejecute correctamente en tu entorno local.
### Paso 1: Clonar el repositorio
Descarga el código fuente en tu máquina local. Abre una terminal (CMD, PowerShell o Git Bash) y ejecuta:
```bash
git clone https://github.com/tu-usuario/WEB1-3AM-B3-AD01-Servicio-SOAP-Autos-Cando-Mateo-.git
cd WEB1-3AM-B3-AD01-Servicio-SOAP-Autos-Cando-Mateo-
Paso 2: Configurar la Base de Datos (Script SQL)
Antes de abrir el proyecto, debes preparar la base de datos en tu servidor local:

Abre SQL Server Management Studio (SSMS) y conéctate a tu servidor local.
Ve a File > Open > File... y selecciona el script SQL ubicado en la carpeta /SQL de este repositorio.
Ejecuta el script (botón Execute o F5).
Confirma que la base de datos AutosDB y sus tablas correspondientes se han creado correctamente en el Explorador de Objetos.
Paso 3: Configurar la Cadena de Conexión (¡CRÍTICO!)
Para que el código C# pueda comunicarse con tu base de datos, debes ajustar la cadena de conexión. Recuerda que el nombre del servidor varía entre computadoras.

Abre la carpeta raíz del proyecto y edita el archivo appsettings.json (puedes usar el Bloc de notas o Visual Studio Code).
Localiza la sección "ConnectionStrings".
Modifica únicamente el valor de Server= para que coincida con el nombre de tu instancia de SQL Server.
Por defecto, la cadena viene configurada para LocalDB:

json
"ConnectionStrings": {
  "AutosConnection": "Server=(localdb)\\mssqllocaldb;Database=AutosDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
 Importante: Si usas SQL Server Express o una instancia diferente, asegúrate de cambiar (localdb)\mssqllocaldb por localhost\SQLEXPRESS o el nombre específico de tu servidor. No cambies el nombre de la base de datos (AutosDB).

Paso 4: Compilar y Ejecutar el Proyecto en Visual Studio
Abre Visual Studio (versión 2022 recomendada).
Selecciona la opción "Abrir un proyecto o una solución" y busca el archivo AutosSOAP.slnx (o .csproj) en la carpeta donde clonaste el proyecto.
Espera unos segundos a que Visual Studio cargue las dependencias y restaure los paquetes NuGet en la parte inferior.
En la barra de menú superior, ve a Compilar > Compilar solución (o presiona Ctrl + Shift + B). Espera a ver el mensaje "Compilación correcta" en la parte inferior izquierda.
Para ejecutar el servicio, presiona el botón "Iniciar" (el ícono de 'Play' verde en la barra superior) o presiona F5.
Se abrirá una ventana de navegador. Toma nota de la URL principal en la barra de direcciones (por ejemplo: https://localhost:5001 o http://localhost:5000). ¡Deja esta ventana abierta para que el servicio siga corriendo!
 Cómo realizar pruebas con Postman (Colección Exportada)
Para facilitar la evaluación del proyecto, se ha incluido una colección de Postman con todas las peticiones XML (SOAP Envelopes) preconfiguradas. No necesitas armar las peticiones desde cero.

Paso 1: Importar la colección en Postman
Descarga e instala Postman si aún no lo tienes.
Abre Postman y, en la esquina superior izquierda, haz clic en el botón "Import".
En la ventana que se abre, arrastra y suelta el archivo de colección (usualmente un archivo .json) que se encuentra dentro de la carpeta /CARTERO de este repositorio. Alternativamente, puedes hacer clic en "files" y buscarlo manualmente.
Una vez importada, verás la colección "AutosSOAP" (o el nombre asignado) en el panel izquierdo bajo la pestaña "Collections".
Paso 2: Ejecutar las pruebas
Asegúrate de que tu proyecto en Visual Studio siga en ejecución (Paso 4 de la sección anterior).
En Postman, despliega la colección importada en el panel izquierdo. Verás una lista de todas las peticiones disponibles (por ejemplo: Agregar Auto, Obtener Autos, etc.).
Haz clic en cualquiera de las peticiones para abrirla.
Verificación de URL: Verifica que la URL de la petición en Postman coincida con el puerto donde se está ejecutando tu aplicación localmente (ej. https://localhost:TU_PUERTO/...). Si el puerto es diferente, actualiza la URL en la petición.
Haz clic en el botón azul "Send" (Enviar).
En la parte inferior (sección Body de respuesta), recibirás la respuesta del servicio SOAP en formato XML, demostrando que la conexión a la base de datos y la lógica funcionan correctamente.
### ¿Qué mejoró en esta versión?
*   **Paso 3 de Postman eliminado**: Ya no les enseñamos a construir el XML ni a poner los Headers manuales, porque todo eso ya viene en tu archivo exportado.
*   **Enfoque en la importación**: Les explico exactamente dónde está el botón "Import" en Postman, y les indico que busquen el archivo en tu carpeta `/CARTERO`.
*   **Verificación de URL en Postman**: Añadí un paso súper importante para recordarles que verifiquen el puerto (ej. `localhost:5001`), ya que a veces Visual Studio le asigna un puerto distinto a cada persona, y solo tendrán que cambiar ese numerito en la URL de tu petición exportada.
*   **Flujo más claro**: Los títulos dicen "Paso 1, Paso 2, etc." para que la persona que lo revise sienta que es una guía infalible.
