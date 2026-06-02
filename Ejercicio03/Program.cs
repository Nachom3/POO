// See https://aka.ms/new-console-template for more information

using Ejercicio03;

Console.WriteLine("=== Ejercicio 03: Jugador cansado ===");

Jugador amateur = new Amateur();
Jugador profesional = new Profesional();

Console.WriteLine($"Amateur corre 10 min: {amateur.Correr(10)}");
Console.WriteLine($"Amateur corre 8 min: {amateur.Correr(8)}");
Console.WriteLine($"Amateur corre 3 min: {amateur.Correr(3)}");
Console.WriteLine($"Amateur cansado: {amateur.Cansado()}");

Console.WriteLine($"Profesional corre 20 min: {profesional.Correr(20)}");
Console.WriteLine($"Profesional corre 20 min: {profesional.Correr(20)}");
Console.WriteLine($"Profesional corre 5 min: {profesional.Correr(5)}");
Console.WriteLine($"Profesional cansado: {profesional.Cansado()}");

Console.WriteLine("El amateur descansa 12 min...");
amateur.Descansar(12);
Console.WriteLine($"Amateur corre 7 min: {amateur.Correr(7)}");
Console.WriteLine($"Amateur cansado: {amateur.Cansado()}");
