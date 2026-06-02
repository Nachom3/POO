namespace Ejercicio05;

public class CuentaBancaria
{
    private decimal saldo;

    protected decimal Saldo
    {
        get { return saldo; }
    }

    public virtual void Depositar(decimal monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("No se puede depositar montos menores o iguales a cero.");
            return;
        }

        saldo += monto;
        Console.WriteLine($"Depósito realizado: {monto}");
    }

    public virtual bool Extraer(decimal monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("No se puede extraer montos menores o iguales a cero.");
            return false;
        }

        if (Saldo < monto)
        {
            Console.WriteLine("Saldo insuficiente.");
            return false;
        }

        saldo -= monto;
        return true;
    }

    public void MostrarSaldo()
    {
        Console.WriteLine($"Saldo actual: {Saldo}");
    }

    protected void Descontar(decimal monto)
    {
        saldo -= monto;
    }
}

public class CajaDeAhorro : CuentaBancaria
{
    public override bool Extraer(decimal monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("No se puede extraer montos menores o iguales a cero.");
            return false;
        }

        if (Saldo < monto)
        {
            Console.WriteLine("Extracción rechazada: saldo insuficiente.");
            return false;
        }

        Descontar(monto);
        Console.WriteLine($"Extracción de ahorro aceptada: {monto}");
        return true;
    }
}

public class CuentaCorriente : CuentaBancaria
{
    private decimal descubiertoMaximo;

    public CuentaCorriente(decimal descubiertoMaximo)
    {
        this.descubiertoMaximo = descubiertoMaximo;
    }

    public override bool Extraer(decimal monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("No se puede extraer montos menores o iguales a cero.");
            return false;
        }

        if (Saldo - monto < -descubiertoMaximo)
        {
            Console.WriteLine("Extracción rechazada: supera el límite de descubierto.");
            return false;
        }

        Descontar(monto);
        Console.WriteLine($"Extracción de corriente aceptada: {monto}");
        return true;
    }
}
