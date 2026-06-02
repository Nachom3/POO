namespace Ejercicio06;

public class Carta
{
    public string Palo { get; }
    public string Valor { get; }

    public Carta(string palo, string valor)
    {
        Palo = palo;
        Valor = valor;
    }

    public override string ToString()
    {
        return $"{Valor} de {Palo}";
    }
}

public class Mazo
{
    private List<Carta> cartas;

    public Mazo()
    {
        cartas = new List<Carta>();
        string[] palos = { "Corazones", "Diamantes", "Tréboles", "Picas" };
        string[] valores = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        foreach (string palo in palos)
        {
            foreach (string valor in valores)
            {
                cartas.Add(new Carta(palo, valor));
            }
        }
    }

    public void Barajar()
    {
        Random random = new Random();

        for (int i = cartas.Count - 1; i > 0; i--)
        {
            int indiceAleatorio = random.Next(i + 1);
            Carta temporal = cartas[i];
            cartas[i] = cartas[indiceAleatorio];
            cartas[indiceAleatorio] = temporal;
        }
    }

    public Carta RobarCarta()
    {
        if (cartas.Count == 0)
        {
            throw new InvalidOperationException("No hay cartas para robar.");
        }

        Carta carta = cartas[0];
        cartas.RemoveAt(0);
        return carta;
    }

    public int CuantasCartasQuedan()
    {
        return cartas.Count;
    }
}

public class Mano
{
    private List<Carta> cartas;

    public Mano()
    {
        cartas = new List<Carta>();
    }

    public void RecibirCarta(Carta carta)
    {
        if (carta != null)
        {
            cartas.Add(carta);
        }
    }

    public void MostrarMano()
    {
        foreach (Carta carta in cartas)
        {
            Console.WriteLine(carta);
        }
    }

    public int CantidadDeCartas()
    {
        return cartas.Count;
    }
}
