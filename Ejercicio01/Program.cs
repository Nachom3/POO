// See https://aka.ms/new-console-template for more information

using Ejercicio01;

Console.WriteLine("=== Ejercicio 01: Semáforo ===");

Semaforo semaforo = new Semaforo("Verde");
semaforo.MostrarColor();

semaforo.PasoDelTiempo(20);
semaforo.MostrarColor();
semaforo.PasoDelTiempo(15);
semaforo.MostrarColor();

semaforo.PonerEnIntermitente();
for (int i = 0; i < 5; i++)
{
    semaforo.MostrarColor();
    semaforo.PasoDelTiempo(1);
}

semaforo.SacarDeIntermitente();
semaforo.PasoDelTiempo(2);
semaforo.MostrarColor();
