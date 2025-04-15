using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
public class Emprestimo
{
    public int Id;
    public Amigo Amigo;
    public Revista Revista;
    public DateTime DataEmprestimo;
    public DateTime DataDevolucao;
    public string StatusEmprestimo;

    public RepositorioCaixa repositorioCaixa;

    public Emprestimo(Amigo amigo, Revista revista)
    {
        Amigo = amigo;
        Revista = revista;
        DataEmprestimo = DateTime.Now;
        DataDevolucao = DataEmprestimo.AddDays((int)Revista.Caixa.Dias.Subtract(DateTime.MinValue).TotalDays);
        StatusEmprestimo = "Aberto";
    }

    public string Validar()
    {
        string erros = "";

        if (Amigo == null)
            erros += "É necessário associar pelo menos um amigo ao empréstimo.\n";

        if (Revista == null)
            erros += "É necessário associar pelo menos uma revista ao empréstimo.\n";

        return erros;
    }
}
