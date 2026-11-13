# TP4 - Suite de Pruebas y Verificación del Producto

## 1. Objetivo

El objetivo de este trabajo práctico es diseñar e implementar una suite de pruebas para verificar el correcto funcionamiento del sistema web de alquileres.

Se busca comprobar que las operaciones principales cumplan con los requisitos establecidos y detectar posibles errores antes de entregar el producto.

## 2. Alcance de las pruebas

Se tomó como requisito principal el RF-01: registrar un alquiler solamente cuando el inmueble exista, se encuentre disponible y los datos ingresados sean válidos.

Al registrar correctamente un alquiler, el estado del inmueble debe cambiar a **Alquilada**. El sistema debe rechazar un nuevo alquiler sobre un inmueble que ya se encuentra alquilado.

## 3. Herramientas utilizadas

- **Visual Studio 2022:** entorno de desarrollo.
- **.NET 8:** plataforma del proyecto.
- **xUnit:** framework para ejecutar las pruebas.
- **Moq:** biblioteca para simular dependencias en las pruebas unitarias.
- **HttpClient:** herramienta para realizar solicitudes HTTP en la prueba funcional.

## 4. Tipos de pruebas implementadas

### Pruebas unitarias

Se implementaron 6 pruebas sobre el servicio de alquileres:

- Registrar un alquiler con datos válidos.
- Rechazar un cliente vacío.
- Rechazar un inmueble inexistente.
- Rechazar un inmueble que ya está alquilado.
- Rechazar una fecha de inicio inválida.
- Aceptar fechas de inicio y fin iguales, según la validación implementada.

### Pruebas de integración

Se implementaron 2 pruebas para verificar el funcionamiento conjunto de los servicios y repositorios:

- Comprobar que al registrar un alquiler se actualice el estado del inmueble.
- Comprobar que no se permita alquilar nuevamente un inmueble que ya está alquilado.

### Prueba funcional (E2E)

Se implementó 1 prueba funcional utilizando HttpClient para interactuar con la API:

- Consultar inmuebles disponibles.
- Registrar un alquiler.
- Verificar que el inmueble cambie su estado a Alquilada.
- Intentar registrar un segundo alquiler sobre el mismo inmueble y comprobar que la API lo rechace.

## 5. Resultados obtenidos

Luego de ejecutar la suite de pruebas mediante `dotnet test`, se obtuvieron los siguientes resultados:

| Tipo de prueba | Cantidad |
|---|---:|
| Unitarias | 6 |
| Integración | 2 |
| Funcionales | 1 |
| **Total** | **9** |

**Resultado final: 9 pruebas aprobadas, 0 errores y 0 omitidas.**

La compilación del proyecto también finalizó correctamente.

## 6. Consideraciones para ejecutar las pruebas

La prueba funcional E2E realiza solicitudes HTTP contra la API. Por este motivo, antes de ejecutar la suite completa es necesario iniciar el servidor web.

Desde la carpeta raíz del proyecto:

```powershell
dotnet run --project .\Alquileres.Servidor\Alquileres.Servidor.csproj --launch-profile https
```

Luego, desde otra terminal:

```powershell
dotnet test .\Alquileres.Tests\Alquileres.Tests.csproj
```

La API debe estar disponible en `https://localhost:7122`.

## 7. Verificación y validación

Las pruebas de verificación permiten comprobar que los componentes del sistema funcionan de acuerdo con lo implementado.

La prueba funcional también permite validar que el comportamiento de la API responda al requisito definido para el registro de alquileres.

## 8. Conclusión

La implementación de esta suite permitió comprobar el comportamiento del módulo de alquileres mediante diferentes niveles de prueba.

Los resultados obtenidos fueron satisfactorios: las 9 pruebas finalizaron correctamente. Esto aporta mayor confianza en el funcionamiento del sistema y permite detectar errores antes de incorporar nuevas funcionalidades.
