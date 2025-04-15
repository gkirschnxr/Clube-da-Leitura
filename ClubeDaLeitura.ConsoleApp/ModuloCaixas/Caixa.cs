
namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;
public class Caixa
{
    public int Id;
    public string Etiqueta;
    public string Cor;
    public DateTime Dias;

    public Caixa (string etiqueta, string cor, DateTime diasEmprestimo)
    {
        Etiqueta = etiqueta;
        Cor = cor;
        Dias = diasEmprestimo;
    }

    public string Validar()
    {
        string erros = "";

        if (Etiqueta.Length < 1 || Etiqueta.Length > 50)
            erros += "O campo 'Etiqueta' náo pode ser maior que 50 caracteres.\n";

        return erros;    
    }
}
