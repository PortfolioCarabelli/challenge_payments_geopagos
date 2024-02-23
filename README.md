# Proyecto de Microservicios para Autorización y Confirmación de Pagos

Este proyecto es una solución que proporciona soporte para la autorización y confirmación de pagos para nuestros clientes. La solución consta de varios microservicios, cada uno encargado de una parte específica del proceso.

## Microservicios

### AuthorizationService

Este microservicio maneja las solicitudes de autorización de pagos. Los clientes pueden enviar solicitudes de autorización, y el servicio las procesa, registra y responde de acuerdo a lo que el procesador del pago dictamine.

### ConfirmationService

Para los clientes que requieran confirmación de autorización, este microservicio maneja las solicitudes de confirmación y realiza las acciones correspondientes, como generar autorizaciones de reversa si la confirmación no se realiza dentro del tiempo especificado.

### ReportingService
Este microservicio se encarga de generar un reporte o una lista de las solicitudes de autorizaciones de pagos aprobadas

### Persistence
Contiene la lógica de acceso a datos, incluidos los modelos de datos y el contexto de la base de datos.

## Tecnologías Utilizadas

- .NET 6
- Entity Framework Core
- AutoMapper
- Ocelot API Gateway
- SQL Server

## Configuración
## Base de Datos
1. Asegúrate de tener SQL Server instalado y en funcionamiento.
2. Actualiza la cadena de conexión en el archivo appsettings.json del proyecto AuthorizationService con los detalles de tu instancia de SQL Server.
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=AuthorizationDb;Trusted_Connection=True;"
}
```
3. Ejecuta las migraciones de base de datos para crear el esquema inicial:
Ejecuta el comando:
```
dotnet ef database update --project Persistence

```
4.
Insertar Clientes
Puedes insertar clientes en la base de datos utilizando SQL Server Management Studio
```
-- Insertar cliente tipo First
INSERT INTO Clients (Name, ClientType) VALUES ('ClienteFirst', 'First');

-- Insertar cliente tipo Second
INSERT INTO Clients (Name, ClientType) VALUES ('ClienteSecond', 'Second');

```

## Ejecución del Proyecto
Abre una terminal en el directorio raíz del proyecto.
Ejecuta el comando:
```
dotnet run --project AuthorizationService
dotnet run --project ApiGateway
dotnet run --project ConfirmationServices
dotnet run --project ReportingService

```
Esto iniciará los servicio en los puertos configurados



