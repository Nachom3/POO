namespace Ejercicio03;

public interface Jugador
{
    bool Correr(int minutos);
    bool Cansado();
    void Descansar(int minutos);
}

public abstract class JugadorBase : Jugador
{
    private int limiteCansancio;
    private int minutosCansado;

    protected JugadorBase(int limiteCansancio)
    {
        this.limiteCansancio = limiteCansancio;
        minutosCansado = 0;
    }

    public bool Correr(int minutos)
    {
        if (minutos <= 0 || Cansado())
        {
            return false;
        }

        if (minutosCansado + minutos > limiteCansancio)
        {
            minutosCansado = limiteCansancio;
            return false;
        }

        minutosCansado += minutos;
        return true;
    }

    public bool Cansado()
    {
        return minutosCansado >= limiteCansancio;
    }

    public void Descansar(int minutos)
    {
        if (minutos <= 0)
        {
            return;
        }

        minutosCansado -= minutos;

        if (minutosCansado < 0)
        {
            minutosCansado = 0;
        }
    }
}

public class Amateur : JugadorBase
{
    public Amateur() : base(20)
    {
    }
}

public class Profesional : JugadorBase
{
    public Profesional() : base(40)
    {
    }
}
