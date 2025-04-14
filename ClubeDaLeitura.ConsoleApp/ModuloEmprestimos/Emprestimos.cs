using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
public class Emprestimos
{
    public int Id;
    public Amigos[] Amigos;
    public Revistas[] Revistas;
    public Caixas[] Caixas;
    public string DataEmprestimo;
    public string DataDevolucao;
    public string StatusEmprestimo;

    public Emprestimos(Amigos[] amigos, Revistas[] revistas, string dataEmprestimo, Caixas caixa)
    {
        Amigos = amigos;
        Revistas = revistas;
        DataEmprestimo = DateTime.Now.ToString("yyyy-MM-dd");
        DataDevolucao = CalcularDataDevolucao();
        Caixas = new[] { caixa };
        StatusEmprestimo = "Aberto"; // Inicializando
    }

    public string CalcularDataDevolucao()
    {
        Caixas caixa = Caixas[0];

        int.TryParse(caixa.Dias, out int diasEmprestimo);
        
        DateTime dataEmprestimo = DateTime.Parse(DataEmprestimo);

        return dataEmprestimo.AddDays(diasEmprestimo).ToString("yyyy-MM-dd");        
    }

    public string Validar()
    {
        string erros = "";

        if (Amigos == null || Amigos.Length == 0)
            erros += "É necessário associar pelo menos um amigo ao empréstimo.\n";

        if (Revistas == null || Revistas.Length == 0)
            erros += "É necessário associar pelo menos uma revista ao empréstimo.\n";

        if (Caixas == null || Caixas.Length == 0)
            erros += "É necessário associar pelo menos uma caixa ao empréstimo.\n";

        return erros;
    }
}
