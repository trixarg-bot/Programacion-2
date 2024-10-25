# Programacion-2

TAREA #6

Objetivo
Crear una API usando .NET Core que será utilizada por agentes de migración de la República Dominicana. Esta API ayudará a los agentes que trabajan en las guaguas (autobuses) que recogen personas que están de manera ilegal en el país.

📋 Lo que debe hacer la API:
Noticias de Migración:
Crea un endpoint que les permita a los agentes ver las noticias más importantes sobre migración. La API deberá conectarse a una página de noticias y mostrar solo los títulos y un pequeño resumen de esas noticias. Usa esta URL para las noticias:

https://remolacha.net/wp-json/wp/v2/posts?search=migraci%C3%B3n&_fields=title,excerpt
Registro de Usuarios:
Los agentes de migración deben poder registrarse en el sistema. Para eso, la API debe recibir la cédula, nombre, apellido, teléfono, correo y clave del agente.

Si ya existe un agente con la misma cédula o correo, el registro debe fallar.

Inicio de Sesión:
Los agentes de migración deben poder iniciar sesión en el sistema usando su cédula o correo y su clave. Si los datos son correctos, la API devolverá la información del agente.

Registro de Incidencias:
Cuando un agente atrape a una persona, deberá poder registrar los datos en la API. La API debe recibir:

Pasaporte, nombre, apellido, WhatsApp, fecha de nacimiento.
Coordenadas (latitud y longitud de dónde fue detenido).
Código del agente que está haciendo el registro.
La API debe devolver un número de confirmación (ID) para cada registro.

Estado del Clima:
Los agentes también necesitan saber cómo está el clima en la zona donde están trabajando. La API debe aceptar las coordenadas (latitud y longitud) y devolver el clima para los próximos días. Para esto, puedes usar una API de clima.

🔧 Lo más importante:
La API debe tener Swagger configurado y documentado. Swagger permite a otros ver y probar los endpoints de la API fácilmente.
Asegúrate de documentar cada endpoint.
