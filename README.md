# TvMaze

Este repositorio contiene una solución con cinco proyectos distintos:

-	Capa de Datos (Librería de Clases)
    Contiene la capa de acceso a datos. Aquí se manejan las operaciones CRUD y manipulación de los archivos .Json donde se guarda la información que devuelve la API externa.
	
-	Capa de Negocio (Librería de Clases).
	Implementa la lógica de negocio. Aquí se aplican las reglas y procesos específicos del dominio.
	
-	Capa de Servicios (Librería de Clases).
	Provee servicios que pueden ser consumidos por la API. Actúa como un intermediario entre la capa de negocio y la API.
	
-	Web API (Proyecto Web).
    	Es el proyecto que expone los servicios a través de HTTP. Desplegado en Azure. (Es el proyecto que debe configurarse por defecto).
	
-	Pruebas Unitarias (Proyecto de Pruebas).
	Contiene las pruebas unitarias para validar el comportamiento de los servicios expuestos a través del proyecto Web Api.
	

# Decisiones Arquitectónicas:
	Separación de Capas
	La solución se divide en capas para mantener una arquitectura limpia y facilitar el mantenimiento y escalabilidad del sistema:

-	Capa de Datos: Aislamos el acceso a la base de datos para que cualquier cambio en la estructura de datos no afecte otras partes del sistema.
-	Uso de Archivos JSON: Para evitar costos adicionales en Azure, se decidió utilizar archivos JSON para simular una base de datos. Esto permite realizar pruebas y   
  	desarrollos sin incurrir en gastos.
- 	Capa de Negocio: La lógica de negocio se maneja aquí, permitiendo aplicar reglas de negocio y algoritmos específicos.
- 	Capa de Servicios: Esta capa actúa como intermediaria y permite que las reglas de negocio se consuman a través de servicios, facilitando la reutilización y el 
  	mantenimiento.
- 	Web API: Expone los servicios a través de HTTP, permitiendo la interacción con clientes externos.
	Pruebas Unitarias: Validan que cada componente individual funcione correctamente, asegurando la calidad del código.

# Despliegue en Azure
La Web API está desplegada en Azure para aprovechar la escalabilidad, seguridad y facilidad de integración que ofrece esta plataforma en la nube.
	
Requisitos Previos
-	.NET 8 SDK instalado.
-	Visual Studio 2022 o superior /  VS Code.
-	Una cuenta de Azure para desplegar la API.
