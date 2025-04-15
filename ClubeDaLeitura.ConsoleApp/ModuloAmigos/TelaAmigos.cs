using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;
public class TelaAmigos
{
    public RepositorioAmigo repositorioAmigos;

    public TelaAmigos(RepositorioAmigo repositorioAmigos)
    {
        this.repositorioAmigos = repositorioAmigos;
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
        Console.Write("      Gerenciador de Amigos      ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("|");

        Console.WriteLine("-----------------------------------\n");

        Console.ResetColor();
    }

    public char ExibirMenu()
    {
        MostrarCabecalho();

        Console.WriteLine("  1  ▸  Registrar novo amigo");
        Console.WriteLine("  2  ▸  Editar cadastro do amigo");
        Console.WriteLine("  3  ▸  Excluir amigo");
        Console.WriteLine("  4  ▸  Visualizar amigos");
        Console.WriteLine("  5  ▸  Ver empréstimos do amigo");

        Console.WriteLine("\n  S  ▸  Voltar");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n Escolha uma opção: ");
        Console.ResetColor();

        char opcaoEscolhida = Console.ReadLine()![0];

        return char.ToUpper(opcaoEscolhida);
    }

    public void RegistrarAmigo()
    {
        MostrarCabecalho();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nCadastrando novo amigo...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        Amigo novoAmigo = ObterDadosAmigo();

        string erros = novoAmigo.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            RegistrarAmigo();

            return;
        }

        repositorioAmigos.CadastrarAmigo(novoAmigo);

        Notificador.ExibirMensagem("O registro foi feito com sucesso", ConsoleColor.Green);
    }

    public void EditarAmigo()
    {
        MostrarCabecalho();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nEditando cadastro do amigo...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        Console.Write("Digite o ID do amigo que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Amigo amigoEditado = ObterDadosAmigo();

        bool conseguiuEditar = repositorioAmigos.EditarAmigo(idSelecionado, amigoEditado);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição do amigo", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("Amigo editado com sucesso", ConsoleColor.Green);
    }

    public void ExcluirAmigo()
    {
        MostrarCabecalho();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nExcluindo cadastro do amigo...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        VisualizarAmigos(true);

        Console.Write("Digite o ID do amigo que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Amigo amigoExcluido = repositorioAmigos.SelecionarAmigoPorId(idSelecionado);

        bool conseguiuExcluir = repositorioAmigos.ExcluirAmigo(idSelecionado);

        if (amigoExcluido == null)
        {
            Notificador.ExibirMensagem("Amigo não encontrado", ConsoleColor.Red);
            return;
        }

        Notificador.ExibirMensagem("Amigo excluído com sucesso", ConsoleColor.Green);
    }

    public void VisualizarAmigos(bool mostrarAmigos)
    {
        if (mostrarAmigos == false)
        {
            MostrarCabecalho();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nVisualizando cadastro dos amigos...");
            Console.WriteLine("-----------------------------------\n");
            Console.ResetColor();
        }

        mostrarAmigos = true;
        if (mostrarAmigos == true)
        {
            Console.WriteLine(
            "{0, -5} | {1, -20} | {2, -20} | {3, -15} | {4, -15}",
            "ID", "Nome:", "Responsável", "Telefone", "Possui Empréstimos?"
            );

            Amigo[] amigosCadastrados = repositorioAmigos.SelecionarAmigo();

            for (int i = 0; i < amigosCadastrados.Length; i++)
            {
                Amigo a = amigosCadastrados[i];

                if (a == null) continue;

                Console.WriteLine(
                    "{0, -5} | {1, -20} | {2, -20} | {3, -15} | {4, -15}",
                    a.Id, a.Nome, a.Responsavel, a.Telefone, a.TemEmprestimosAtivos() // validar quantos emprestimos possui? atraso?
                    );
            }

            Notificador.ExibirMensagem("\nPressione ENTER para continuar...", ConsoleColor.Yellow);
        }
    }
    public Amigo ObterDadosAmigo()
    {
        Console.Write("Digite o nome do amigo: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o responsável pelo amigo: ");
        string responsavel = Console.ReadLine()!;

        Console.Write("Digite o telefone do amigo: ");
        string telefone = Console.ReadLine()!;

        Amigo amigo = new Amigo(nome, responsavel, telefone);

        return amigo;
    }

    internal void EmprestimosAmigo()
    {
        throw new NotImplementedException();
    }
}
