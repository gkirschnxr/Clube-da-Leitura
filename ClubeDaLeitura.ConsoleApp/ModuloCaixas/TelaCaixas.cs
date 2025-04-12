using ClubeDaLeitura.ConsoleApp.ModuloAmigos;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;
public class TelaCaixas
{
    public RepositorioCaixas repositorioCaixas;
    public TelaCaixas(RepositorioCaixas repositorioCaixas)
    {
        this.repositorioCaixas = repositorioCaixas;
    }
    public void MostrarCabecalho()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("|   Clube da Leitura do Gustavo   |");
        Console.WriteLine("|                                 |");

        Console.Write("|");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("      Gerenciador de Caixas      ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("|");

        Console.WriteLine("-----------------------------------\n");

        Console.ResetColor();
    }

    public char ExibirMenu()
    {
        MostrarCabecalho();

        Console.WriteLine("  1  ▸ Registrar nova caixa");
        Console.WriteLine("  2  ▸ Editar caixa");
        Console.WriteLine("  3  ▸ Excluir caixa");
        Console.WriteLine("  4  ▸ Visualizar caixas");

        Console.WriteLine("\n  S  ▸ Voltar");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n Escolha uma opção: ");
        Console.ResetColor();

        char opcaoEscolhida = Console.ReadLine()![0];

        return opcaoEscolhida;
    }

    public void RegistrarCaixa()
    {
        MostrarCabecalho();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nCadastrando novo amigo...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        Caixas novaCaixa = new Caixas();

    }

    public void EditarCaixa()
    {
        throw new NotImplementedException();
    }

    public void ExcluirCaixa()
    {
        throw new NotImplementedException();
    }

    public void VisualizarCaixas(bool v)
    {
        throw new NotImplementedException();
    }
    public void ObterDadosCaixa()
    {

    }
}
