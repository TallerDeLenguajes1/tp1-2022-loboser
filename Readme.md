
# TP-01 Lobo, Sergio Zair 馃摑  

## Investigue y responda

Cuando se captura una excepci贸n, existen muchas formas de lanzar la excepci贸n al
m茅todo llamador. Algunas de estas se encuentran en el c贸digo a continuaci贸n. Investigue
en qu茅 se diferencian cada una de ellas. Responda en el Readme.md

```
    catch(Exception ex)
    {

        throw;

        throw new AlgunaExcepcion("mensaje de error 1", ex);

        throw new AlgunaExcepcion("mensaje de error 2");

        throw ex;

    }
```
El **throw;** y el **throw ex;** hacen relativamente lo mismo en este caso, que es **lanzar** la misma excepcion que se **captur贸** con el **catch** valga la redundancia, pero en otros casos la variable **ex** podria contener otra excepcion y no la de ingreso en el catch, entonces con el **throw ex;** se estaria lanzando esa otra excepci贸n.

En los casos de **throw new AlgunaExcepcion("mensaje de error 1", ex);** y **throw new AlgunaExcepcion("mensaje de error 2");** se estar铆a lanzando una nueva excepci贸n ya sea una creada por nosotros mismos previamente o una de las ya existentes, pero con un mensaje adicional en estos casos y en particular el primer caso la lanzaria con una **excepcion interna** al contrario de la segunda.

