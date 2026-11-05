1. Objetivo de la aplicación

La aplicación permite a los empleados registrar las horas trabajadas asociándolas a cuentas de cargo dentro de una quincena determinada.El foco está en la simplicidad de uso, la visualización clara de totales y la integración con Entra ID para autenticación corporativa.

2. Autenticación y acceso

El usuario accede a la aplicación mediante autenticación con Microsoft Entra ID.

Una vez autenticado:

Se identifica al usuario de forma única.

Se cargan sus registros de horas (si existen) para la quincena actual.

3. Cabecera de la aplicación

La aplicación muestra una cabecera fija en la parte superior de la pantalla con los siguientes elementos:

Nombre del usuario autenticado, visible de forma clara.

Fecha en curso, correspondiente al día actual.

Botón de ayuda:

Proporciona acceso a información básica sobre el uso de la aplicación.

Está orientado a resolver dudas rápidas sobre el registro de horas.

Botón de logout:

Permite cerrar la sesión del usuario de forma explícita.

Redirige al usuario al flujo de autenticación de Entra ID.

La cabecera permanece visible durante toda la interacción con la aplicación.

4. Gestión de quincenas

El sistema divide el calendario en quincenas naturales:

Primera quincena: días 1–15.

Segunda quincena: días 16–fin de mes.

Al acceder a la aplicación:

Se detecta automáticamente la quincena actual según la fecha del sistema.

Se muestran únicamente los días correspondientes a esa quincena.

El usuario puede visualizar claramente:

El rango de fechas de la quincena activa.

Los días incluidos en ella.

5. Estructura del grid de registro de horas

El núcleo de la aplicación es un grid editable con la siguiente estructura:

5.1 Cabecera del grid

Primera fila: fechas de la quincena (por ejemplo: 1, 2, 3… 15).

Segunda fila: día de la semana correspondiente a cada fecha (L, M, X, J, V, S, D).

5.2 Filas de trabajo (cuentas de cargo)

Cada fila representa una cuenta de cargo.

Para cada fila:

El usuario selecciona una cuenta de cargo desde un listado disponible.

Introduce el número de horas trabajadas por día en las celdas correspondientes.

Formato de horas admitido:

Valores numéricos enteros (por ejemplo, 8).

Valores numéricos con un único decimal (por ejemplo, 7.5).

No se admiten más de un decimal ni valores no numéricos.

Las celdas validan el formato introducido y están orientadas a una edición rápida.

5.3 Totales automáticos

El grid calcula y muestra automáticamente:

Total por cuenta de cargo (fila):

Suma de todas las horas introducidas en la quincena para esa cuenta.

Total por día (columna):

Suma de todas las horas registradas ese día, independientemente de la cuenta.

Los totales se actualizan en tiempo real al modificar cualquier celda.

6. Gestión de cuentas de cargo

La aplicación dispone de un mecanismo para administrar las cuentas de cargo:

Existe un listado de cuentas de cargo disponibles.

El usuario puede:

Añadir una nueva cuenta de cargo mediante una acción explícita (por ejemplo, botón “Añadir cuenta”).

Ver inmediatamente la nueva cuenta disponible para su uso en el grid.

Las cuentas de cargo añadidas quedan disponibles para futuras quincenas.

7. Comportamiento esperado del usuario

El usuario:

Accede, revisa la quincena actual y registra sus horas.

Puede distribuir horas en varias cuentas de cargo el mismo día.

Puede introducir fracciones de hora con precisión de un decimal.

Visualiza en todo momento los totales diarios y por cuenta.

La experiencia debe ser:

Rápida.

Clara.

Sin necesidad de navegación adicional para registrar horas.

8. Alcance del piloto

Este piloto se centra exclusivamente en:

Autenticación.

Cabecera con información del usuario y acciones básicas.

Visualización de quincenas.

Registro de horas en grid.

Validación básica de formato de horas.

Cálculo de totales.

Gestión básica de cuentas de cargo.

Quedan fuera del alcance inicial:

Flujos de aprobación.

Exportación de datos.

Informes históricos avanzados.

Si quieres, puedo transformar esta descripción en historias de usuario con criterios de aceptación, o generar un prompt técnico optimizado para GitHub Copilot que implemente directamente la estructura de la aplicación.