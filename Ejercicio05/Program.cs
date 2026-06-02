// See https://aka.ms/new-console-template for more information

using Ejercicio05;

Console.WriteLine("=== Ejercicio 05: Cajero automatico ===");

Console.WriteLine("--- Prueba individual de cuentas ---");

var ahorro = new CajaDeAhorro();
ahorro.Depositar(1000);
ahorro.Extraer(400);
ahorro.Extraer(800); // debe rechazarse
ahorro.MostrarSaldo();

var corriente = new CuentaCorriente(500);
corriente.Depositar(200);
corriente.Extraer(600); // queda en -400, es válido
corriente.Extraer(200); // supera el descubierto, debe rechazarse
corriente.MostrarSaldo();

Console.WriteLine("\n--- Prueba de banco y transferencias ---");

Banco banco = new Banco();
var ahorroBanco = new CajaDeAhorro();
var corrienteBanco = new CuentaCorriente(500);

banco.AgregarCuenta(ahorroBanco);
banco.AgregarCuenta(corrienteBanco);

ahorroBanco.Depositar(1000);
banco.Transferir(ahorroBanco, corrienteBanco, 300); // debe funcionar
banco.Transferir(ahorroBanco, corrienteBanco, 900); // debe rechazarse

Console.WriteLine("Fin del ejercicio 5");
