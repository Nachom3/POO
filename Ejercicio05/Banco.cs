using System.Collections.Generic;

namespace Ejercicio05;

public class Banco
{
    private List<CuentaBancaria> cuentas;

    public Banco()
    {
        cuentas = new List<CuentaBancaria>();
    }

    public void AgregarCuenta(CuentaBancaria cuenta)
    {
        if (cuenta == null)
        {
            Console.WriteLine("No se puede agregar una cuenta nula.");
            return;
        }

        if (cuentas.Contains(cuenta))
        {
            Console.WriteLine("Esa cuenta ya está registrada.");
            return;
        }

        cuentas.Add(cuenta);
        Console.WriteLine("Cuenta agregada correctamente.");
    }

    public void Transferir(CuentaBancaria origen, CuentaBancaria destino, decimal monto)
    {
        if (!cuentas.Contains(origen) || !cuentas.Contains(destino))
        {
            Console.WriteLine("Transferencia rechazada: ambas cuentas deben estar registradas en el banco.");
            return;
        }

        if (monto <= 0)
        {
            Console.WriteLine("Transferencia rechazada: el monto debe ser mayor a cero.");
            return;
        }

        if (!origen.Extraer(monto))
        {
            Console.WriteLine("Transferencia rechazada: no se pudo descontar el monto de la cuenta origen.");
            return;
        }

        destino.Depositar(monto);
        Console.WriteLine($"Transferencia aprobada: {monto} transferido.");
    }
}
