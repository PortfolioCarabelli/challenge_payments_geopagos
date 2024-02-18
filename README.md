# Proyecto de Microservicios para Autorización y Confirmación de Pagos

Este proyecto es una solución que proporciona soporte para la autorización y confirmación de pagos para nuestros clientes. La solución consta de varios microservicios, cada uno encargado de una parte específica del proceso.

## Microservicios

### AuthorizationService

Este microservicio maneja las solicitudes de autorización de pagos. Los clientes pueden enviar solicitudes de autorización, y el servicio las procesa, registra y responde de acuerdo a lo que el procesador del pago dictamine.

### ConfirmationService

Para los clientes que requieran confirmación de autorización, este microservicio maneja las solicitudes de confirmación y realiza las acciones correspondientes, como generar autorizaciones de reversa si la confirmación no se realiza dentro del tiempo especificado.

## Tecnologías Utilizadas

- .NET 6
- Entity Framework Core
- AutoMapper
- Ocelot API Gateway
- RabbitMQ y MassTransit
- Docker
- SQL Server

## Estructura del Proyecto

El repositorio está organizado de la siguiente manera:

- `AuthorizationService`: Contiene el microservicio de autorización.
- `ConfirmationService`: Contiene el microservicio de confirmación.
- `ApiGateway`: Contiene la API Gateway configurada con Ocelot.
- `docker-compose.yml`: Archivo de Docker Compose para ejecutar todos los servicios.
- `README.md`: Este archivo.

## Instrucciones de Ejecución

### Requisitos Previos

- Tener instalado Docker y Docker Compose en el sistema.

### Pasos para Ejecutar

1. Clonar el repositorio en tu máquina local.
2. Abrir una terminal en la raíz del repositorio.
3. Ejecutar el siguiente comando para iniciar los servicios:

```bash
docker-compose up
Esto levantará todos los microservicios y la API Gateway en contenedores Docker.

Acceso a los Servicios
AuthorizationService: http://localhost:5000
ConfirmationService: http://localhost:5001
API Gateway (Ocelot): http://localhost:5002
