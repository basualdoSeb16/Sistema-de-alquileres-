# TP N.º 2 – Arquitectura y patrones de diseño

## 1. Descripción del proyecto

El proyecto **Sistema de Alquileres** es una API desarrollada en C# con ASP.NET Core. Permite gestionar propiedades y alquileres mediante operaciones CRUD (crear, consultar, modificar y eliminar).

El objetivo de este trabajo es mejorar la organización interna del servidor, separar las responsabilidades y aplicar patrones de diseño que faciliten el mantenimiento y la ampliación del sistema.

El alcance de los cambios se limita a la capa del servidor, sin incorporar nuevas funcionalidades de negocio ni modificar la interfaz gráfica del cliente.

## 2. Problema identificado

En la versión original del proyecto, los controladores se encargaban de atender las solicitudes HTTP, acceder a las listas de datos y ejecutar las reglas de negocio. Esto generaba una mezcla de responsabilidades y dificultaba el mantenimiento del código.

Además, el controlador de alquileres consultaba directamente al controlador de propiedades mediante el método estático `ObtenerPropiedadPorId`. Esta dependencia provocaba un acoplamiento entre ambos controladores.

Como consecuencia, los cambios en la forma de acceder a las propiedades podían afectar al funcionamiento de los alquileres. También se dificultaba la reutilización y la comprobación independiente de la lógica de negocio.

## 3. Alternativa sin utilizar un patrón de diseño

Una alternativa sencilla habría sido mantener las listas en los controladores y crear métodos auxiliares para consultar, registrar o modificar los datos.

Sin embargo, esta solución no habría resuelto completamente el problema, porque los controladores seguirían concentrando varias responsabilidades. Otra posibilidad habría sido duplicar las consultas y validaciones, pero esto generaría repetición de código y aumentaría el riesgo de inconsistencias.

Por estos motivos, se decidió reorganizar el servidor mediante una arquitectura por capas y utilizar el patrón Repository para separar el acceso a los datos del resto de la aplicación.

## 4. Decisión arquitectónica

Se reorganizó el servidor en las siguientes capas y componentes:

- **Controllers:** reciben las solicitudes HTTP, invocan los servicios y devuelven las respuestas correspondientes.
- **Services:** contienen y coordinan las reglas de negocio relacionadas con las propiedades y los alquileres.
- **Repositories:** administran el acceso y las operaciones sobre las colecciones de datos.
- **Interfaces:** definen los contratos que deben cumplir los repositorios y los servicios.
- **DTOs (Data Transfer Objects):** permiten definir los datos que se reciben para crear o actualizar propiedades y alquileres.
- **Models:** representan las entidades principales del sistema.

Esta organización permite que cada componente tenga una responsabilidad más específica y reduce la dependencia directa entre los controladores.

## 5. Patrón de diseño seleccionado

### Repository

Se eligió el patrón **Repository** porque el problema principal estaba relacionado con el acceso a los datos desde los controladores.

Este patrón introduce una capa encargada de realizar las operaciones sobre los datos y oculta los detalles de almacenamiento al resto de la aplicación.

En el proyecto se implementaron:

- `IPropiedadRepository` y `PropiedadRepository`.
- `IAlquilerRepository` y `AlquilerRepository`.

Los servicios utilizan las interfaces de los repositorios en lugar de acceder directamente a las listas almacenadas en ellos.

### Justificación de la elección

Repository resulta adecuado porque permite separar el acceso a los datos de las reglas de negocio y facilita modificar la implementación del almacenamiento en el futuro.

No se incorporaron patrones como Factory o Strategy porque no se identificó una necesidad concreta que justificara su utilización. El objetivo no es agregar patrones innecesariamente, sino elegir soluciones que respondan a problemas reales del sistema.

## 6. Implementación realizada

Para aplicar la decisión arquitectónica, se incorporaron los siguientes componentes:

- Interfaces e implementaciones de los repositorios.
- Interfaces e implementaciones de los servicios.
- DTOs para las operaciones de creación y actualización.
- Controladores que delegan las operaciones en los servicios.
- Registro de dependencias en `Program.cs`.

Se configuró la inyección de dependencias para que ASP.NET Core proporcione las implementaciones necesarias a cada componente.

De esta manera, los controladores ya no necesitan acceder directamente a los repositorios ni depender de métodos estáticos de otros controladores para realizar las operaciones del sistema.

El almacenamiento continúa siendo en memoria. Por lo tanto, los datos no constituyen un almacenamiento permanente y pueden perderse al reiniciar la aplicación.

## 7. Principios y beneficios obtenidos

La reorganización permite aplicar los siguientes principios:

- **Separación de responsabilidades:** cada capa cumple una función determinada.
- **Bajo acoplamiento:** los componentes se relacionan mediante interfaces y servicios, reduciendo las dependencias directas.
- **Inversión de dependencias:** los servicios dependen de abstracciones para acceder a los repositorios.
- **Inyección de dependencias:** las implementaciones se registran en `Program.cs` y son proporcionadas por el contenedor de ASP.NET Core.
- **Mantenibilidad:** los cambios en una capa pueden realizarse con menor impacto sobre las demás.

Estos principios facilitan la comprensión, las pruebas y la evolución futura del código.

## 8. Verificación del funcionamiento

Luego de realizar los cambios, se verificó el funcionamiento de las operaciones CRUD de propiedades y alquileres.

También se revisó que los controladores utilizaran los servicios y que estos trabajaran con las interfaces de los repositorios.

El objetivo de estas comprobaciones fue confirmar que la reorganización arquitectónica mantuviera el funcionamiento del sistema y mejorara la distribución de responsabilidades.

## 9. Uso de Git y GitHub

Para desarrollar los cambios se utilizó una rama de trabajo independiente llamada `feature/arquitectura-crud`.

Los cambios se registraron mediante Git y se publicaron en GitHub. Posteriormente, se creó un Pull Request hacia la rama `main` para revisar e integrar la modificación.

El Pull Request fue integrado mediante un merge exitoso, incorporando los cambios de arquitectura a la rama principal.

## 10. Reflexión sobre el uso de inteligencia artificial

Durante el trabajo utilicé inteligencia artificial como apoyo para analizar la arquitectura original del servidor e identificar problemas de acoplamiento y responsabilidades mezcladas.

Le solicité propuestas para separar el acceso a los datos, las reglas de negocio y las solicitudes HTTP. Antes de aceptar las sugerencias, comparé las alternativas con el código existente y con los objetivos del práctico.

Verifiqué que las operaciones CRUD continuaran funcionando y revisé que los controladores utilizaran servicios e interfaces. También evalué los patrones sugeridos para evitar incorporar soluciones innecesarias.

Finalmente, mantuve el alcance del trabajo en la capa del servidor y prioricé los cambios que mejoraban la organización y el mantenimiento del código.

## 11. Conclusión

La reorganización del servidor permitió separar las responsabilidades, reducir el acoplamiento entre componentes y centralizar el acceso a los datos mediante repositorios.

La aplicación del patrón Repository, junto con los servicios, las interfaces, los DTOs y la inyección de dependencias, proporciona una estructura más clara y mantenible.

El trabajo permitió comprender que los patrones de diseño deben seleccionarse en función de los problemas concretos del proyecto y no simplemente por la cantidad de patrones que se puedan implementar.
