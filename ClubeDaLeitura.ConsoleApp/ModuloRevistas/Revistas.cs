using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;
public class Revistas
{
    public int Id;
    public string Titulo;
    public string Edição;
    public string AnoPublicacao;
    public Caixas[] Caixa; //obrigatorio

    public Revistas(string titulo, string edicao, string anoPublicacao, Caixas[] caixa)
    {
        Titulo = titulo;
        Edição = edicao;
        AnoPublicacao = anoPublicacao;
        Caixa = caixa;
    }

    public string Validar()
    {
        string erros = "";
        if (Titulo.Length < 2 || Titulo.Length > 100)
            erros += "O campo 'Título' deve contar no mínimo 2 letras.\n";
        if (Edição.Length < 1 || Edição.Length > 50)
            erros += "O campo 'Edição' não pode ser maior que 50 caracteres.\n";
        if (!string.IsNullOrEmpty(ValidarAnoPublicacao()))
            erros += "O campo 'Ano de Publicação' deve conter um ano válido (4 dígitos).\n";
        return erros;
    }

    public string ValidarAnoPublicacao()
    {
        if (int.TryParse(AnoPublicacao, out int ano))
        {
            if (ano >= DateTime.MinValue.Year && ano <= DateTime.MaxValue.Year)
                return string.Empty;
        }
        return "O ano informado é inválido.";
    }
}
