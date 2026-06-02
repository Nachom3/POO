// See https://aka.ms/new-console-template for more information

using Ejercicio06;

Console.WriteLine("=== Ejercicio 06: Mazo de cartas ===");

Mazo mazo = new Mazo();
mazo.Barajar();

Mano jugador1 = new Mano();
Mano jugador2 = new Mano();

for (int i = 0; i < 3; i++)
{
    jugador1.RecibirCarta(mazo.RobarCarta());
    jugador2.RecibirCarta(mazo.RobarCarta());
}

jugador1.MostrarMano();
jugador2.MostrarMano();

Console.WriteLine($"Cartas restantes en el mazo: {mazo.CuantasCartasQuedan()}");
