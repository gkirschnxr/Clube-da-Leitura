namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;
public class Caixas
{
    public int Id;
    public string Etiqueta;
    public string Cor;
    public string Dias;

    public Caixas (int id, string etiqueta, string cor, string diasEmprestimo)
    {
        Etiqueta = etiqueta;
        Cor = cor;
        Dias = diasEmprestimo;
    }



}
