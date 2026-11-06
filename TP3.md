# TP N.º 3 – Refactorización y Code Review

## Sistema de Gestión de Alquileres

**Proyecto:** Sistema de Gestión de Alquileres  
**Carrera:** Tecnicatura Universitaria en Programación  
**Institución:** UTN – Facultad Regional Tucumán

---

## 1. Objetivo del práctico

El objetivo de este práctico fue analizar y mejorar el código existente del Sistema de Gestión de Alquileres mediante técnicas de refactorización y revisión de código (Code Review).

Se buscó mejorar la organización, legibilidad y mantenimiento del código sin modificar el comportamiento original del sistema ni afectar las funcionalidades que ya estaban implementadas.

Para realizar el trabajo se seleccionó el módulo de Propiedades, específicamente las clases `PropiedadService` y `PropiedadRepository`.

## 2. Selección del código original

Se seleccionó el módulo de Propiedades porque ya contaba con las operaciones principales del CRUD:

- Obtener todas las propiedades.
- Obtener una propiedad por su identificador.
- Crear una propiedad.
- Modificar una propiedad.
- Eliminar una propiedad.

El código se encontraba funcionando correctamente, pero presentaba algunas oportunidades de mejora relacionadas con la repetición de instrucciones y la organización de determinadas responsabilidades.

## 3. Diagnóstico del código original

Luego de analizar el código se identificaron los siguientes aspectos:

### PropiedadService

- Se repetía la operación `Trim()` al asignar la dirección y el tipo de propiedad, tanto al crear como al modificar.
- La validación del estado se encontraba directamente dentro del método `Modificar()`, haciendo que este método tuviera más instrucciones de las necesarias.

### PropiedadRepository

- El método `Eliminar()` realizaba varias operaciones para buscar una propiedad, comprobar si existía y luego eliminarla.
- Esta lógica podía simplificarse utilizando un método propio de la colección `List`.

### Principios y criterios relacionados

- **DRY:** se detectó repetición de código en la normalización de textos.
- **SRP:** se buscó organizar mejor las tareas dentro de los métodos mediante la extracción de operaciones específicas.
- **DIP:** ya se encontraba aplicado, debido a que `PropiedadService` depende de la interfaz `IPropiedadRepository` y no de una implementación concreta.
- **Código limpio:** se buscó mejorar la claridad y reducir instrucciones innecesarias.

No se consideró necesario modificar toda la arquitectura porque la separación entre servicios, repositorios e interfaces ya estaba implementada.

## 4. Refactorización realizada

Se realizaron modificaciones puntuales en dos archivos.

### 4.1. PropiedadService.cs

Se creó el método privado `NormalizarTexto()`:

```csharp
private static string NormalizarTexto(string texto)
{
    return texto.Trim();
}
```

Este método permite centralizar la operación de eliminación de espacios al principio y al final de un texto.

También se creó el método `ValidarEstado()`:

```csharp
private static void ValidarEstado(string estado)
{
    if (estado != "Disponible" &&
        estado != "Alquilada")
    {
        throw new ArgumentException(
            "El estado debe ser Disponible o Alquilada.");
    }
}
```

De esta manera, la validación del estado quedó separada del método `Modificar()`.

Los métodos `Crear()` y `Modificar()` ahora utilizan `NormalizarTexto()` para asignar la dirección y el tipo de propiedad.

### 4.2. PropiedadRepository.cs

Se simplificó el método `Eliminar()`.

**Código anterior:**

```csharp
public bool Eliminar(int id)
{
    Propiedad? propiedad = ObtenerPorId(id);

    if (propiedad == null)
        return false;

    propiedades.Remove(propiedad);
    return true;
}
```

**Código refactorizado:**

```csharp
public bool Eliminar(int id)
{
    return propiedades.RemoveAll(p => p.Id == id) > 0;
}
```

El método `RemoveAll()` elimina los elementos que cumplen la condición indicada y devuelve la cantidad de elementos eliminados.

Por eso, al comparar el resultado con cero, el método devuelve `true` si encontró y eliminó la propiedad, o `false` si no encontró ninguna.

## 5. Pruebas realizadas

Después de realizar las modificaciones se comprobó el funcionamiento del proyecto.

Se verificaron las siguientes operaciones:

- Consulta de propiedades.
- Creación de propiedades.
- Modificación de propiedades.
- Validación de estados permitidos.
- Eliminación de propiedades existentes.
- Intento de eliminación de propiedades inexistentes.

Los resultados fueron satisfactorios y el CRUD continuó funcionando correctamente.

## 6. Creación de la rama y Pull Request

Para trabajar de manera organizada se utilizó una rama independiente:

`refactor/mejorar-propiedad-service`

Los cambios se registraron mediante el siguiente commit:

```bash
git add .
git commit -m "Refactorizar servicios y repositorios de propiedades"
```

Posteriormente, se subió la rama al repositorio remoto:

```bash
git push --set-upstream origin refactor/mejorar-propiedad-service
```

Se creó un Pull Request hacia la rama principal `main`.

**Título del Pull Request:**

Refactorización de PropiedadService y PropiedadRepository.

El Pull Request permite revisar los cambios antes de incorporarlos a la rama principal.

## 7. Code Review

Se solicitó a un compañero la revisión de los cambios realizados en el Pull Request.

La revisión debe contemplar:

- Claridad de los nombres de métodos y variables.
- Ausencia de duplicación innecesaria.
- Organización de las responsabilidades.
- Correcto funcionamiento del CRUD.
- Mantenimiento de la arquitectura existente.
- Posibles errores o mejoras adicionales.

Las observaciones recibidas se documentarán para determinar cuáles corresponde aplicar.

## 8. Corrección de observaciones

Una vez realizada la revisión, se analizarán los comentarios del compañero.

Las observaciones pertinentes serán corregidas en la misma rama del Pull Request y se volverán a comprobar las funcionalidades afectadas.

## 9. Justificación de observaciones no aplicadas

En caso de recibir observaciones que no se consideren necesarias, se explicarán los motivos por los cuales no se aplicaron.

La decisión deberá estar fundamentada en el funcionamiento del sistema, los objetivos del práctico y el mantenimiento de una implementación sencilla.

## 10. Conclusión

La refactorización permitió mejorar la organización y legibilidad del módulo de Propiedades sin modificar su comportamiento.

Se redujo la repetición de código mediante la creación de métodos auxiliares y se simplificó la eliminación de registros en el repositorio.

Además, se mantuvo la arquitectura existente basada en interfaces, servicios y repositorios, evitando incorporar complejidad innecesaria.

Este trabajo permitió aplicar conceptos de código limpio, DRY, organización de responsabilidades y revisión de código mediante GitHub Pull Requests.
