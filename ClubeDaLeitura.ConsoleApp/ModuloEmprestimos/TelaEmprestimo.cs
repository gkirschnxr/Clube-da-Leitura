using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
public class TelaEmprestimo
{
    public RepositorioEmprestimo repositorioEmprestimo;
    public RepositorioAmigo repositorioAmigo;
    public RepositorioRevista repositorioRevista;
    public RepositorioCaixa repositorioCaixa;

    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
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

        Emprestimo novoEmprestimo = ObterDadosEmprestimo();

        string erros = novoEmprestimo.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            RegistrarEmprestimo();

            return;
        }

        repositorioEmprestimo.CadastrarEmprestimo(novoEmprestimo);

        Notificador.ExibirMensagem("O registro foi feito com sucesso", ConsoleColor.Green);
    }

    public Emprestimo ObterDadosEmprestimo()
    {
        VisualizarAmigos();
        Console.WriteLine("Qual o amigo que fez o empréstimo? ");
        int idAmigo = Convert.ToInt32(Console.ReadLine());

        Amigo amigoSelecionado = repositorioAmigo.SelecionarAmigoPorId(idAmigo);

        if (amigoSelecionado == null)
            throw new InvalidOperationException("Nenhum amigo foi selecionado.");

        VisualizarRevistas();
        Console.WriteLine("Qual revista foi emprestada?");
        int idRevista = Convert.ToInt32(Console.ReadLine());

        Revista revistaSelecionada = repositorioRevista.SelecionarRevistaPorId(idRevista);

        if (revistaSelecionada == null)
            throw new InvalidOperationException("Nenhuma revista foi selecionada.");

        DateTime dataEmprestimo = DateTime.Now;

        return new Emprestimo(amigoSelecionado, revistaSelecionada);
    }

    public void VisualizarAmigos()
    {        
        Console.WriteLine(
        "{0, -5} | {1, -20} | {2, -20} | {3, -15}",
        "ID", "Nome:", "Responsável", "Telefone" // "Possui Empréstimos?"
        );

        Amigo[] amigosCadastrados = repositorioAmigo.SelecionarAmigo();

        for (int i = 0; i < amigosCadastrados.Length; i++)
        {
            Amigo a = amigosCadastrados[i];

            if (a == null) continue;

            Console.WriteLine(
                "{0, -5} | {1, -20} | {2, -20} | {3, -15}",
                a.Id, a.Nome, a.Responsavel, a.Telefone  // a.ObterEmprestimos() // validar quantos emprestimos possui? atraso?
                );
        }     
    }

    public void VisualizarRevistas()
    {
        Console.WriteLine(
        "{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -15} | {5, -15}",
        "ID", "Título:", "N’ da Edição", "Ano da Publicação", "Status", "Caixa"
        );

        Revista[] revistasCadastradas = repositorioRevista.SelecionarRevista();

        for (int i = 0; i < revistasCadastradas.Length; i++)
        {
            Revista r = revistasCadastradas[i];

            if (r == null) continue;

            string nomeCaixa = r.Caixa != null ? r.Caixa.Etiqueta : "Sem Caixa";

            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), r.CorCaixa);
            Console.WriteLine(
                            "{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -15} | {5, -15}",
                            r.Id, r.Titulo, r.Edicao, r.AnoPublicacao, r.StatusRevista, nomeCaixa
                            );
            Console.ResetColor();
        }
    }

    // ---------------------------------------------------------------------------------------------------------------------

    public void DevolucaoEmprestimo()
    {
        MostrarCabecalho();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nDevolvendo empréstimo...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        repositorioEmprestimo.DevolucaoEmprestimo();

        Console.WriteLine("Digite o ID do empréstimo que deseja devolver: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        if (repositorioEmprestimo.SelecionarEmprestimoPorId(idSelecionado) == null)
        {
            Notificador.ExibirMensagem("Empréstimo não encontrado", ConsoleColor.Red);
            return;
        }

        Notificador.ExibirMensagem("A devolução foi feita com sucesso", ConsoleColor.Green);
    }

    public void VisualizarEmprestimo(bool mostrarEmprestimos)
    {
        if (mostrarEmprestimos == false)
        {
            MostrarCabecalho();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nVisualizando emprestimos...");
            Console.WriteLine("-----------------------------------\n");
            Console.ResetColor();
        }

        mostrarEmprestimos = true;
        if (mostrarEmprestimos == true)
        {
            Console.WriteLine(
            "{0, -5} | {1, -20} | {2, -20} | {3, -25} | {4, -25} | {5, -15}",
            "ID", "Amigo", "Revista", "Data do Empréstimo", "Data para Devolução", "Status"
            );

            Emprestimo[] emprestimosCadastrados = repositorioEmprestimo.SelecionarEmprestimo();

            for (int i = 0; i < emprestimosCadastrados.Length; i++)
            {
                Emprestimo e = emprestimosCadastrados[i];

                if (e == null) continue;

                Console.WriteLine(
                    "{0, -5} | {1, -20} | {2, -20} | {3, -25} | {4, -25} | {5, -15}",
                    e.Id, e.Amigo, e.Revista, e.DataEmprestimo, e.DataDevolucao, e.StatusEmprestimo
                    );
                Console.ResetColor();
            }

            Notificador.ExibirMensagem("\nPressione ENTER para continuar...", ConsoleColor.Yellow);
        }
    }
}
