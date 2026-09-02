markdown
-  Servicio SOAP de Autos (AutosSOAP)
- Descripción
**AutosSOAP** es un servicio web basado en el protocolo SOAP desarrollado en C# (.NET). Este proyecto tiene como objetivo proporcionar operaciones para la gestión de un catálogo de automóviles, interactuando directamente con una base de datos SQL Server. Permite realizar operaciones estándar para administrar la información de los vehículos a través de un servicio web robusto y estandarizado.
- Tecnologías Utilizadas
- **Lenguaje:** C#
- **Framework:** .NET (ASP.NET Core / WCF según corresponda)
- **Base de Datos:** Microsoft SQL Server (LocalDB)
- **Arquitectura/Protocolo:** Servicios Web SOAP
- **Herramientas de Pruebas:** Postman / SoapUI (opcional para pruebas de consumo)
--  Estructura del Proyecto
A continuación, se detalla la estructura principal de las carpetas del repositorio:
- `/Datos`: Contiene la lógica de acceso a datos y configuración del contexto de la base de datos.
- `/Modelos`: Define las clases y entidades del dominio (ej. Auto).
- `/Servicios`: Contiene la implementación de la lógica de negocio y los contratos del servicio SOAP.
- `/SQL`: Scripts necesarios para la creación de la base de datos y sus tablas.
- `appsettings.json`: Archivo principal de configuración de la aplicación, incluye la cadena de conexión a la base de datos.
- `Program.cs` / `Startup.cs`: Punto de entrada y configuración de los servicios de la aplicación.
---
--  Instrucciones de Despliegue y Uso
Sigue estos pasos cuidadosamente para ejecutar el proyecto en tu entorno local:
### 1. Clonar el repositorio
Primero, clona este repositorio en tu máquina local:
```bash
git clone https://github.com/tu-usuario/WEB1-3AM-B3-AD01-Servicio-SOAP-Autos-Cando-Mateo-.git
cd WEB1-3AM-B3-AD01-Servicio-SOAP-Autos-Cando-Mateo-
2. Configurar la Base de Datos (Script SQL)
Antes de levantar el proyecto, debes crear la estructura de la base de datos:

Abre SQL Server Management Studio (SSMS) o tu gestor de base de datos preferido.
Localiza el script SQL ubicado en la carpeta /SQL del proyecto.
Ejecuta el script en tu servidor de SQL Server local. Esto creará la base de datos AutosDB y las tablas necesarias.
3. Configurar la Cadena de Conexión (¡IMPORTANTE!)
Antes de ejecutar la aplicación, debes asegurarte de que la cadena de conexión apunte a tu servidor de base de datos local. Ten en cuenta que el nombre del servidor varía entre computadoras.

Abre el archivo appsettings.json (o appsettings.Development.json) que se encuentra en la raíz del proyecto.
Localiza la sección "ConnectionStrings".
Modifica el valor de Server para que coincida con tu instancia de SQL Server. Por defecto, está configurado para usar LocalDB:
json
"ConnectionStrings": {
  "AutosConnection": "Server=(localdb)\\mssqllocaldb;Database=AutosDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
Nota: Si estás usando una instancia nombrada de SQL Server (por ejemplo, SQLEXPRESS), cambia (localdb)\\mssqllocaldb por localhost\\SQLEXPRESS o el nombre de tu servidor.

4. Compilar y Ejecutar
Abre la solución (AutosSOAP.slnx o el archivo .csproj) en Visual Studio.
Restaura los paquetes NuGet (usualmente Visual Studio lo hace automáticamente al abrir el proyecto o al compilar).
Compila la solución (Ctrl + Shift + B).
Ejecuta el proyecto (F5 o el botón "Iniciar").
5. Consumir el Servicio
Una vez que el proyecto esté en ejecución, se abrirá el navegador o te mostrará la URL donde se aloja el WSDL del servicio SOAP. Puedes utilizar herramientas como Postman o SoapUI importando la URL del WSDL para empezar a realizar peticiones XML y probar los diferentes métodos del servicio.

