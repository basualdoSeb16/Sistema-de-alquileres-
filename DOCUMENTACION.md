Documentación de ramas y resolución de conflicto

1. Organización de ramas

Para el proyecto Alquileres se utilizó `main` como rama principal.

Se crearon ramas independientes para desarrollar cambios sin modificar directamente la rama principal.

Las ramas utilizadas fueron:

* `feature/validar-precio`
* `feature/mostrar-propiedades`
* `conflicto-a`
* `conflicto-b`

La rama `feature/validar-precio` se utilizó para agregar validaciones al registro de propiedades.

La rama `feature/mostrar-propiedades` se utilizó para realizar una mejora en la interfaz gráfica.

Las ramas `conflicto-a` y `conflicto-b` fueron utilizadas para realizar una prueba controlada de conflicto de integración.

2. Funcionalidad: validar precio

En la rama `feature/validar-precio` se agregaron dos cambios independientes.

Primer commit:

`8d8da79 feat: validar precio de propiedad`

Se agregó una validación para impedir que una propiedad tenga un precio menor o igual a cero.

Segundo commit:

`7b29b67 feat: validar que el campo direccion no este vacio`

Se agregó una validación para impedir que la dirección de una propiedad esté vacía.

La rama fue integrada a `main` mediante un Pull Request.

3. Funcionalidad: mostrar propiedades

En la rama `feature/mostrar-propiedades` se realizó una mejora relacionada con la interfaz gráfica.

El cambio fue registrado mediante un commit:

`c66033f feat: Mejora en la interfaz grafica`

4. Conflicto controlado

Para realizar el conflicto controlado se crearon las ramas:

* `conflicto-a`
* `conflicto-b`

Ambas ramas modificaron la misma sección del archivo:

`Alquileres.Servidor/Controllers/PropiedadController.cs`

La modificación se realizó dentro del método `Get()`.

Rama conflicto-a

Se modificó el mensaje a:

`Listado de propiedades obtenido correctamente`

El cambio fue registrado mediante:

`f8ace86 docs: actualizar mensaje de propiedades`

Rama conflicto-b

La misma sección fue modificada de otra manera:

`Propiedades disponibles obtenidas correctamente`

El cambio fue registrado mediante:

`f994242 docs: ajustar mensaje de propiedades disponibles`

5. Generación del conflicto

Primero se integró la rama `conflicto-a` en `main`.

Posteriormente se intentó integrar `conflicto-b`.

Git detectó que ambas ramas habían modificado la misma sección del archivo y no pudo realizar la combinación automáticamente.

Se produjo un conflicto de contenido en:

`Alquileres.Servidor/Controllers/PropiedadController.cs`

6. Resolución manual

Se analizaron las dos versiones antes de resolver el conflicto.

La primera versión indicaba que se trataba de un listado de propiedades.

La segunda versión indicaba que se trataba de propiedades disponibles.

Se decidió conservar la información relevante de ambas modificaciones y combinarlas en un único mensaje:

`Listado de propiedades disponibles obtenido correctamente`

Se eliminaron las marcas de conflicto agregadas por Git y se guardó el archivo.

7. Commit de resolución

Una vez solucionado el conflicto, se agregó el archivo y se creó el siguiente commit:

`239611e resolve: combinar mensajes de propiedades`

Este commit documenta la resolución manual del conflicto.

8. Resultado

El historial de Git permite comprobar que las dos ramas realizaron modificaciones diferentes y que posteriormente fueron integradas mediante una resolución manual.

El gráfico del historial muestra:

* `conflicto-a`
* `conflicto-b`
* el conflicto generado
* el commit de resolución

También se realizó un Pull Request para integrar una de las ramas de funcionalidad a `main`.
