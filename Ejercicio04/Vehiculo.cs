namespace Ejercicio04;

public interface IVehiculo
{
    void Mover(int tiempo);
    int Posicion();
    void ReiniciarPosicion();
}

public class Bicicleta : IVehiculo
{
    private int velocidad;
    private int posicion;

    public Bicicleta()
    {
        velocidad = 10;
        posicion = 0;
    }

    public void Mover(int tiempo)
    {
        if (tiempo <= 0)
        {
            return;
        }

        posicion += velocidad * tiempo;
    }

    public int Posicion()
    {
        return posicion;
    }

    public void ReiniciarPosicion()
    {
        posicion = 0;
    }
}

public class Camion : IVehiculo
{
    private int velocidad;
    private int posicion;

    public Camion()
    {
        velocidad = 30;
        posicion = 0;
    }

    public void Mover(int tiempo)
    {
        if (tiempo <= 0)
        {
            return;
        }

        posicion += velocidad * tiempo;
    }

    public int Posicion()
    {
        return posicion;
    }

    public void ReiniciarPosicion()
    {
        posicion = 0;
    }
}

public class Auto : IVehiculo
{
    private int velocidad;
    private int posicion;

    public Auto(int velocidadInicial = 40)
    {
        velocidad = velocidadInicial;
        if (velocidad <= 0)
        {
            velocidad = 40;
        }

        posicion = 0;
    }

    public void Mover(int tiempo)
    {
        if (tiempo <= 0)
        {
            return;
        }

        posicion += velocidad * tiempo;
    }

    public int Posicion()
    {
        return posicion;
    }

    public void ReiniciarPosicion()
    {
        posicion = 0;
    }
}

public class Carrera
{
    public void Competir(IVehiculo primerVehiculo, IVehiculo segundoVehiculo, int tiempo)
    {
        primerVehiculo.Mover(tiempo);
        segundoVehiculo.Mover(tiempo);

        int posicionPrimer = primerVehiculo.Posicion();
        int posicionSegundo = segundoVehiculo.Posicion();

        Console.WriteLine($"Competencia de {tiempo} segundos");
        Console.WriteLine($"Vehiculo 1: {posicionPrimer} metros");
        Console.WriteLine($"Vehiculo 2: {posicionSegundo} metros");

        if (posicionPrimer > posicionSegundo)
        {
            Console.WriteLine("El vehiculo 1 llegó más lejos.");
        }
        else if (posicionSegundo > posicionPrimer)
        {
            Console.WriteLine("El vehiculo 2 llegó más lejos.");
        }
        else
        {
            Console.WriteLine("Ambos vehículos empataron.");
        }
    }
}
