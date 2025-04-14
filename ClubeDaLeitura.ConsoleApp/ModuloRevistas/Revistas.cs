using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;
public class Revistas
{
    public int Id;
    public string Titulo;
    public string Edicao;
    public string AnoPublicacao;
    public string StatusRevista;
    public Caixas[] Caixa; //obrigatorio

    public Revistas(string titulo, string edicao, string anoPublicacao, string statusRevista, Caixas[] caixa)
    {
        Titulo = titulo;
        Edicao = edicao;
        AnoPublicacao = anoPublicacao;
        StatusRevista = "Disponível";
        Caixa = caixa;
    }

    public string CorCaixa => Caixa.Length > 0 ? Caixa[0].Cor : "15";

    public string Validar()
    {
        string erros = "";
        if (Titulo.Length < 2 || Titulo.Length > 100)
            erros += "O campo 'Título' deve contar no mínimo 2 letras.\n";
        if (Edicao.Length < 1 || Edicao.Length > 50)
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
