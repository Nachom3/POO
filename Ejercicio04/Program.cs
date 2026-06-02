// See https://aka.ms/new-console-template for more information

using Ejercicio04;

Console.WriteLine("=== Ejercicio 04: Bicicletas, autos y camiones ===");

Auto fiat = new Auto(45);
Bicicleta bici = new Bicicleta();
Camion camion = new Camion();

bici.Mover(20);
Console.WriteLine(bici.Posicion());
bici.Mover(10);
Console.WriteLine(bici.Posicion());

Carrera carrera = new Carrera();
carrera.Competir(fiat, camion, 10);
carrera.Competir(fiat, bici, 5);
