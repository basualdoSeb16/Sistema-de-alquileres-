# TP5 - Mejora del ciclo y automatización

## 1. Objetivo

El objetivo de este trabajo es mejorar el proceso de desarrollo del Sistema de Alquileres mediante la automatización de tareas, la incorporación de pruebas y la refactorización del código existente.

Se busca mejorar la calidad y el mantenimiento del proyecto sin modificar el funcionamiento de sus funcionalidades principales.

## 2. Integración continua (CI)

Se implementó un proceso de integración continua utilizando **GitHub Actions**.

Se creó el archivo `.github/workflows/dotnet.yml`, que permite ejecutar automáticamente una serie de pasos cuando se realizan cambios en el repositorio.

### Tareas automatizadas

El pipeline realiza las siguientes operaciones:

1. Descarga el repositorio.
2. Configura el entorno .NET 8.
3. Restaura las dependencias necesarias.
4. Compila el proyecto del servidor.
5. Inicia la API.
6. Ejecuta las pruebas automatizadas.

La integración continua permite detectar errores de compilación o pruebas fallidas antes de integrar los cambios a la rama principal.

**Resultado:** el workflow se ejecutó correctamente en GitHub Actions.

## 3. Suite de pruebas y medición inicial

Para comprobar el funcionamiento del sistema se utiliza una suite de pruebas automatizadas desarrollada con **xUnit**.

También se utiliza **Moq** para simular dependencias en las pruebas unitarias y **Coverlet** para medir la cobertura del código.

### Métrica seleccionada

Se eligió la cobertura de código como métrica para conocer qué proporción del código es ejecutada durante las pruebas automatizadas.

Se midieron dos indicadores:

- Cobertura de líneas: porcentaje de líneas de código recorridas por las pruebas.
- Cobertura de ramas: porcentaje de caminos de decisión recorridos por las pruebas.

### Resultados iniciales

Antes de realizar la refactorización, se obtuvieron los siguientes resultados:

| Métrica | Cobertura inicial |
|---|---:|
| Líneas | 42,23 % |
| Ramas | 31,03 % |

## 4. Identificación y refactorización de un Code Smell

Durante la revisión del código se identificó un problema de **código duplicado** en la clase `AlquilerService`.

La búsqueda de propiedades y la validación de su existencia se repetían en distintos métodos, generando código innecesario y dificultando el mantenimiento.

### Mejora realizada

Para solucionar este problema se creó el método privado:

`ObtenerPropiedadExistente(int id)`

Este método centraliza la búsqueda de una propiedad y la validación de su existencia.

Luego se reutiliza desde los métodos que necesitan realizar esa operación, evitando repetir la misma lógica.

### Objetivo de la refactorización

- Reducir la duplicación de código.
- Mejorar la organización de la clase.
- Facilitar el mantenimiento.
- Conservar el comportamiento original del sistema.

No se modificaron las funcionalidades principales ni los endpoints de la API.

## 5. Medición posterior y comparación

Una vez realizada la refactorización, se ejecutaron nuevamente las pruebas automatizadas y se midió la cobertura utilizando Coverlet.

**Resultado de las pruebas: 9 aprobadas y 0 errores.**

### Comparación de resultados

| Métrica | Antes | Después | Diferencia |
|---|---:|---:|---:|
| Cobertura de líneas | 42,23 % | 43,28 % | +1,05 puntos |
| Cobertura de ramas | 31,03 % | 31,48 % | +0,45 puntos |

### Conclusión de la medición

Se observó un incremento en ambas métricas después de realizar la refactorización.

Además, las nueve pruebas continuaron aprobándose, lo que permitió comprobar que los cambios conservaron el comportamiento esperado.

La cobertura es una métrica de apoyo: un porcentaje mayor no garantiza por sí solo que el sistema esté libre de errores.

## 6. Deuda técnica identificada y postergada

Durante el desarrollo se identificaron algunas mejoras que podrían incorporarse en futuras versiones del sistema.

Se decidió postergar su implementación para mantener el alcance actual del proyecto y evitar agregar complejidad innecesaria.

### Mejoras pendientes

**1. Incorporación de una base de datos**

Actualmente, los repositorios trabajan con listas en memoria. Se propone incorporar una base de datos para lograr una persistencia permanente de la información.

Se posterga porque requiere configurar la conexión, diseñar las tablas y adaptar los repositorios existentes.

**2. Implementación de autenticación y autorización**

Se propone incorporar un sistema de inicio de sesión y control de permisos según los roles de usuario, como empleado, gerente y administrador.

Se posterga porque requiere definir políticas de seguridad, gestionar credenciales y proteger los distintos endpoints de la API.

**3. Ampliación de las pruebas automatizadas**

Se propone aumentar la cantidad de pruebas para cubrir más escenarios, especialmente casos de error, validaciones y operaciones relacionadas con los alquileres.

Se posterga porque en esta etapa se priorizó completar las funcionalidades principales y asegurar el funcionamiento de las operaciones CRUD existentes.

### Justificación

Estas mejoras se consideran parte de la deuda técnica del proyecto. No se implementaron en esta etapa porque se priorizó mejorar la calidad del código existente, incorporar pruebas automatizadas y configurar un proceso de integración continua.

Se espera abordar estos aspectos en futuras iteraciones.

## 7. Reflexión sobre el uso de inteligencia artificial

Durante la realización de este trabajo se utilizó inteligencia artificial como herramienta de apoyo para comprender conceptos, revisar el código y proponer posibles mejoras.

La IA ayudó a identificar la duplicación de código en `AlquilerService`, sugirió la extracción de un método para centralizar la validación y colaboró en la documentación de las modificaciones realizadas.

Sin embargo, las sugerencias no se incorporaron automáticamente. Se revisó el código propuesto, se comprobó que respetara la estructura del proyecto y se ejecutaron las pruebas para verificar que el comportamiento del sistema continuara siendo correcto.

También se utilizó como apoyo para comprender la configuración de GitHub Actions y analizar los resultados de cobertura.

Como conclusión, la inteligencia artificial resultó una herramienta útil para agilizar el desarrollo y facilitar el aprendizaje, pero fue necesario revisar y validar sus propuestas antes de aplicarlas.

## 8. Conclusión final

A través de este práctico se logró mejorar el ciclo de desarrollo del Sistema de Alquileres mediante la incorporación de integración continua, pruebas automatizadas, medición de cobertura y refactorización.

Se identificó y corrigió un problema de código duplicado, manteniendo el comportamiento esperado del sistema y obteniendo una mejora en los porcentajes de cobertura.

Además, se documentaron las mejoras pendientes como deuda técnica y se reflexionó sobre el uso responsable de la inteligencia artificial durante el desarrollo.

El trabajo permitió comprender la importancia de automatizar las verificaciones, medir la calidad del código y realizar mejoras graduales para facilitar el mantenimiento futuro del software.
