1. Semáforo
Escribir un programa utilizando programación orientada a objetos que permita crear objetos
del tipo Semaforo.
Secuencia de colores
Un semáforo debe cambiar de color siguiendo esta secuencia de forma cíclica:
•
•
•
•
Rojo — 30 segundos
Rojo + Amarillo — 2 segundos
Verde — 20 segundos
Amarillo — 2 segundos
Métodos requeridos
–
–
–
–
pasoDelTiempo(segundos): avanza el estado interno del semáforo la cantidad de
segundos indicada.
mostrarColor(): muestra el color actual del semáforo.
ponerEnIntermitente(): activa el modo intermitente. En este modo el semáforo
alterna entre "Amarillo" y "Apagado" cada 1 segundo.
sacarDeIntermitente(): desactiva el modo intermitente y retoma la secuencia normal.
Introducción a la POO
1Programación Orientada a Objetos | Prácticas
Inicialización
Al crear un semáforo se debe poder definir el color inicial. El semáforo siempre arranca
desde el segundo 0 dentro de ese color, independientemente de cuál sea.
Ejemplo:
Semaforo semaforo = new Semaforo("Verde");
Esto crea un semáforo en Verde, que permanecerá en ese color durante los próximos 20
segundos antes de cambiar.