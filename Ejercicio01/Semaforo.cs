namespace Ejercicio01;

public class Semaforo
{
    private readonly string[] secuenciaColores =
    {
        "Rojo",
        "Rojo + Amarillo",
        "Verde",
        "Amarillo"
    };

    private readonly int[] duraciones = { 30, 2, 20, 2 };

    private int indiceColor;
    private int segundoEnColorActual;
    private bool intermitente;
    private bool mostrarAmarilloEnIntermitente;

    public Semaforo(string colorInicial)
    {
        indiceColor = TraducirColor(colorInicial);
        segundoEnColorActual = 0;
        intermitente = false;
        mostrarAmarilloEnIntermitente = true;
    }

    public void PasoDelTiempo(int segundos)
    {
        if (segundos <= 0)
        {
            return;
        }

        if (intermitente)
        {
            for (int i = 0; i < segundos; i++)
            {
                mostrarAmarilloEnIntermitente = !mostrarAmarilloEnIntermitente;
            }

            return;
        }

        int segundosPorAvanzar = segundos;

        while (segundosPorAvanzar > 0)
        {
            int restantesEnColor = duraciones[indiceColor] - segundoEnColorActual;

            if (segundosPorAvanzar < restantesEnColor)
            {
                segundoEnColorActual += segundosPorAvanzar;
                break;
            }

            segundosPorAvanzar -= restantesEnColor;
            indiceColor = (indiceColor + 1) % secuenciaColores.Length;
            segundoEnColorActual = 0;
        }
    }

    public void MostrarColor()
    {
        Console.WriteLine(ColorActual());
    }

    public void PonerEnIntermitente()
    {
        if (intermitente)
        {
            return;
        }

        intermitente = true;
        mostrarAmarilloEnIntermitente = true;
    }

    public void SacarDeIntermitente()
    {
        intermitente = false;
        mostrarAmarilloEnIntermitente = false;
    }

    private string ColorActual()
    {
        if (intermitente)
        {
            return mostrarAmarilloEnIntermitente ? "Amarillo" : "Apagado";
        }

        return secuenciaColores[indiceColor];
    }

    private int TraducirColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
        {
            return 0;
        }

        string colorLimpio = color.Trim().ToLowerInvariant();

        if (colorLimpio == "rojo") return 0;
        if (colorLimpio == "rojo + amarillo") return 1;
        if (colorLimpio == "verde") return 2;
        if (colorLimpio == "amarillo") return 3;

        return 0;
    }
}
