namespace ClubeDaLeitura.ConsoleApp.Compartilhado;
public static class GeradorDeIDs
{
    public static int IdAmigos;
    public static int IdCaixas;
    public static int IdRevistas;

    public static int GerarIdAmigos()
    {
        IdAmigos++;

        return IdAmigos;
    }
    public static int GerarIdCaixas()
    {
        IdCaixas++;

        return IdCaixas;
    }
    public static int GerarIdRevistas()
    {
        IdRevistas++;

        return IdRevistas;
    }
}
