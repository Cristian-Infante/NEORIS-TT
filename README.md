# NEORIS Library — Prueba Técnica .NET

Sistema de gestión de libros y autores desarrollado en C# con arquitectura limpia.

## Tecnologías

| Capa | Tecnología |
|---|---|
| Back-End API | ASP.NET Web API 2 — .NET Framework 4.8 |
| Front-End | ASP.NET MVC 5 — .NET Framework 4.8 |
| Base de datos | SQL Server 2022 (Docker) |
| ORM | Entity Framework Core 3.1 |
| Inyección de dependencias | Autofac |

## Estructura de la solución

```
NEORIS.Domain          → Entidades, interfaces de repositorio, excepciones
NEORIS.Application     → DTOs, interfaces de servicio, implementación de servicios
NEORIS.Infrastructure  → AppDbContext, repositorios (EF Core)
NEORIS.Api             → REST API con Swagger (puerto 5050)
NEORIS.Web             → Vistas Razor MVC, consume la API vía HTTP (puerto 5051)
```

## Requisitos previos

- [.NET Framework 4.8 Developer Pack](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- JetBrains Rider o Visual Studio 2022

## Ejecución

**1. Iniciar SQL Server**

```bash
docker compose up -d
```

Esperar ~20 segundos antes de continuar.

**2. Restaurar paquetes NuGet**

```bash
nuget restore NEORIS.sln
```

**3. Ejecutar ambos proyectos**

Desde Rider: usar la configuración Compound que inicia `NEORIS.Api` y `NEORIS.Web` simultáneamente.

La base de datos se crea automáticamente en el primer arranque de la API.

## URLs

| Aplicación | URL |
|---|---|
| Swagger (API) | <http://localhost:5050/swagger> |
| Front-End Web | <http://localhost:5051> |

## Reglas de negocio

- Todos los campos son obligatorios.
- El número máximo de libros permitidos se configura en `NEORIS.Api/Web.config` → `MaxBooksAllowed` (valor por defecto: `10`).
- Si se supera el límite: `"No es posible registrar el libro, se alcanzó el máximo permitido."`
- Si el autor no existe: `"El autor no está registrado"`
