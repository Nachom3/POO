// See https://aka.ms/new-console-template for more information

using System;
using Ejercicio02;

Console.WriteLine("=== Ejercicio 02: Cronometro ===");

Cronometro cronometro = new Cronometro();

for (int i = 0; i < 5000; i++)
{
    cronometro.IncrementarTiempo();
}

Console.WriteLine(cronometro.MostrarTiempo());
