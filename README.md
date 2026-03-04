# 🎫 Sistema de Gestión de Tickets - Soporte Técnico

Este es un sistema web desarrollado en **ASP.NET MVC 5** diseñado para centralizar y gestionar reportes de fallas técnicas en una organización. Permite el registro de usuarios, creación de tickets, asignación de técnicos y seguimiento de soluciones.

## 🚀 Características Principales
* **Panel de Control (Index):** Visualización de tickets con estados y prioridades resaltadas mediante colores.
* **Registro de Usuarios:** Formulario con asignación de ID automática para nuevos empleados o técnicos.
* **Gestión de Reportes:** Creación, edición detallada y cierre de tickets con observaciones técnicas.
* **Interfaz Moderna:** Diseño responsivo utilizando **Bootstrap 5** e iconos de **Bootstrap Icons**.
* **Seguridad de Datos:** Validaciones de lado del servidor y del cliente, y manejo de tipos nulos para evitar errores de ejecución.

## 🛠️ Tecnologías Utilizadas
* **Lenguaje:** C#
* **Framework:** ASP.NET MVC 5 (.NET Framework)
* **Base de Datos:** SQL Server (Entity Framework DB First)
* **Frontend:** HTML5, CSS3, Bootstrap 5, jQuery
* **Iconos:** Bootstrap Icons

## 📋 Requisitos para ejecución local
Para que el proyecto funcione en tu equipo, necesitas:
1. **Visual Studio 2019/2022** con la carga de trabajo "Desarrollo de ASP.NET y web".
2. **SQL Server Management Studio (SSMS)**.

## 🔧 Instrucciones de Instalación

### 1. Preparar la Base de Datos
Antes de correr el proyecto, debes crear la base de datos:
1. Abre SSMS y crea una base de datos llamada `SOPORTE_TECNICO`.
2. Ejecuta el script SQL que se encuentra en la carpeta `/Database` (o el script que adjunté en el repositorio) para crear las tablas y los registros iniciales de Roles y Departamentos.

### 2. Configurar el Proyecto
1. Clona este repositorio o descarga el ZIP.
2. Abre el archivo `.sln` en Visual Studio.
3. Ve al archivo `Web.config`.
4. Busca la sección `<connectionStrings>` y actualiza el campo `Data Source` con el nombre de tu servidor local (ejemplo: `Data Source=TU_PC\SQLEXPRESS`).

### 3. Ejecutar
Presiona `F5` o el botón **Google Chrome/IIS Express** en Visual Studio para iniciar la aplicación.

## 📸 Capturas de Pantalla
<img width="937" height="321" alt="image" src="https://github.com/user-attachments/assets/dadbc027-65ee-4ca0-98b8-94a03119878e" />
<img width="937" height="359" alt="image" src="https://github.com/user-attachments/assets/2a7a4d50-8983-43e8-9708-4c972da93753" />
<img width="937" height="406" alt="image" src="https://github.com/user-attachments/assets/c2530615-811d-492d-9826-b3eade0cb410" />
<img width="940" height="229" alt="image" src="https://github.com/user-attachments/assets/d324a25e-d944-44ab-bf1c-df4261c95aa3" />
<img width="939" height="380" alt="image" src="https://github.com/user-attachments/assets/112ad4fc-8ec4-4261-9c78-6d51bb69c56c" />
<img width="917" height="424" alt="image" src="https://github.com/user-attachments/assets/82fa344a-08dd-4a58-a9e6-9354f6c86c89" />


---
**Desarrollado por:** [plopsandev](https://github.com/plopsandev)
