using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
public class TelaEmprestimos
{
    public RepositorioEmprestimos repositorioEmprestimos;
    public RepositorioAmigos repositorioAmigos;
    public RepositorioRevistas repositorioRevistas;

    public TelaEmprestimos(RepositorioEmprestimos repositorioEmprestimos, RepositorioAmigos repositorioAmigos, RepositorioRevistas repositorioRevistas)
    {
        this.repositorioEmprestimos = repositorioEmprestimos;
        this.repositorioAmigos = repositorioAmigos;
        this.repositorioRevistas = repositorioRevistas;
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
        Console.Write("   Gerenciador de Empréstimos   ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("|");

        Console.WriteLine("-----------------------------------\n");

        Console.ResetColor();
    }

    public char ExibirMenu()
    {
        MostrarCabecalho();

        Console.WriteLine("  1  ▸ Registrar novo empréstimo");
        Console.WriteLine("  2  ▸ Registrar Devolução");
        Console.WriteLine("  3  ▸ Visualizar empréstimos");

        Console.WriteLine("\n  S  ▸ Voltar");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n Escolha uma opção: ");
        Console.ResetColor();

        char opcaoEscolhida = Console.ReadLine()![0];

        return opcaoEscolhida;
    }

    public void RegistrarEmprestimo()
    {
        MostrarCabecalho();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nCadastrando novo empréstimo...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        Emprestimos novoEmprestimo = ObterDadosEmprestimo();

        string erros = novoEmprestimo.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            RegistrarEmprestimo();

            return;
        }

        repositorioEmprestimos.RegistrarEmprestimo(novoEmprestimo);

        Notificador.ExibirMensagem("O registro foi feito com sucesso", ConsoleColor.Green);
    }

    public Emprestimos ObterDadosEmprestimo()
    {
        string statusEmprestimo = "Aberto";

        Console.WriteLine("Qual o amigo que fez o empréstimo? ");
        Amigos[] amigos = repositorioAmigos.SelecionarAmigo();

        Console.WriteLine("Qual revista foi emprestada? ");
        Revistas[] revistas = repositorioRevistas.SelecionarRevista();

        Console.WriteLine("Qual a data do empréstimo? ");
        DateTime dataEmprestimo = DateTime.Now;

        Emprestimos emprestimo = new Emprestimos(amigos, revistas, dataEmprestimo.ToString("yyyy-MM-dd"));

        return emprestimo;
    }



    // ---------------------------------------------------------------------------------------------------------------------


    public void DevolucaoEmprestimo() // nao finalizado
    {
        MostrarCabecalho();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nDevolvendo empréstimo...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        repositorioEmprestimos.DevolucaoEmprestimo();
        Console.WriteLine("Digite o ID do empréstimo que deseja devolver: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());



        Notificador.ExibirMensagem("A devolução foi feita com sucesso", ConsoleColor.Green);
    }

    internal void VisualizarEmprestimo()
    {
        throw new NotImplementedException();
    }
}
