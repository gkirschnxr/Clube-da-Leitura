using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using System.Reflection.Metadata.Ecma335;

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
        Console.WriteLine("\nCadastrando nova caixa...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        Caixas novaCaixa = ObterDadosCaixa();

        string erros = novaCaixa.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem("Houve um erro durante o registro da Caixa", ConsoleColor.Red);

            RegistrarCaixa();

            return;
        }

        Notificador.ExibirMensagem("Caixa adicionada com sucesso!", ConsoleColor.Green);
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

    public Caixas ObterDadosCaixa()
    {
        Console.WriteLine("Digite a etiqueta da caixa: ");
        string etiqueta = Console.ReadLine()!;

        Console.WriteLine("Qual será a cor da caixa? ");
        ConsoleColor[] cores = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        for (int i = 0; i < cores.Length; i++)
        {
            Console.ForegroundColor = cores[i];
            Console.WriteLine($"{i}: {cores[i]}");
        }

        Console.ResetColor();
        Console.WriteLine("Selecione o número da cor ");
        string corInput = Console.ReadLine()!;

        if (int.TryParse(corInput, out int escolha) && escolha >= 0 && escolha < cores.Length)
        {
            ConsoleColor corEscolhida = cores[escolha];

            Console.ForegroundColor = corEscolhida;
            Console.WriteLine($"\nVocê escolheu: {corEscolhida}");
            Console.ResetColor();

        }
        else Console.WriteLine("Escolha inválida.");

        Console.WriteLine("Digite os dias de empréstimo da caixa: ");
        string diasEmprestimo = Console.ReadLine()!;

        Caixas caixa = new Caixas(etiqueta, corInput, diasEmprestimo);

        return caixa;
    }
}
