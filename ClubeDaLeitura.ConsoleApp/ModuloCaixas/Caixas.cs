
namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;
public class Caixas
{
    public int Id;
    public string Etiqueta;
    public string Cor;
    public string Dias;

    public Caixas (string etiqueta, string cor, string diasEmprestimo)
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

        //if (Cor.Length < 3 || Responsavel.Length > 100)
        //    erros += "O campo 'Responsavel' deve contar no mínimo 3 letras.\n";

        if (Dias.Length < 0)
            erros += "O campo 'Dias' deve ser maior que zero.\n";

        return erros;
    
    }
}
