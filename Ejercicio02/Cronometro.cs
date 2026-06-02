namespace Ejercicio02;

public class Cronometro
{
    private int minutos;
    private int segundos;

    public void Reiniciar()
    {
        minutos = 0;
        segundos = 0;
    }

    public void IncrementarTiempo()
    {
        segundos++;

        if (segundos > 59)
        {
            minutos++;
            segundos = 0;
        }
    }

    public string MostrarTiempo()
    {
        return $"{minutos} minutos, {segundos} segundos";
    }
}
