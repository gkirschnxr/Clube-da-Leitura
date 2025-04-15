using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;
public class TelaRevistas
{
    public RepositorioRevista repositorioRevistas;
    public RepositorioCaixa repositorioCaixas;
    public TelaRevistas(RepositorioRevista repositorioRevistas, RepositorioCaixa repositorioCaixas)
    {
        this.repositorioRevistas = repositorioRevistas;
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
        Console.Write("     Gerenciador de Revistas     ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("|");

        Console.WriteLine("-----------------------------------\n");

        Console.ResetColor();
    }

    public char ExibirMenu()
    {
        MostrarCabecalho();

        Console.WriteLine("  1  ▸  Registrar nova revista");
        Console.WriteLine("  2  ▸  Editar revista");
        Console.WriteLine("  3  ▸  Excluir revista");
        Console.WriteLine("  4  ▸  Visualizar revistas");
        Console.WriteLine("  5  ▸  Verificar disponibilidade das revistas");

        Console.WriteLine("\n  S  ▸  Voltar");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n Escolha uma opção: ");
        Console.ResetColor();

        char opcaoEscolhida = Console.ReadLine()![0];

        return char.ToUpper(opcaoEscolhida);
    }

    public void RegistrarRevista()
    {
        MostrarCabecalho();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nCadastrando nova revista...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        Revista novaRevista = ObterDadosRevista();

        string erros = novaRevista.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            RegistrarRevista();

            return;
        }

        repositorioRevistas.CadastrarRevista(novaRevista);

        Notificador.ExibirMensagem("O registro foi feito com sucesso", ConsoleColor.Green);
    }

    public void EditarRevista()
    {
        MostrarCabecalho();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nEditando revista...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        Console.Write("Digite o ID da revista: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Revista revistaEditada = ObterDadosRevista();

        bool conseguiuEditar = repositorioRevistas.EditarRevista(idSelecionado, revistaEditada);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição do amigo", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("Amigo editado com sucesso", ConsoleColor.Green);
    }

    public void ExcluirRevista()
    {
        MostrarCabecalho();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nExcluindo revista...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        VisualizarRevista(true);

        Console.Write("Digite o ID da revista que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Revista revistaExcluida = repositorioRevistas.SelecionarRevistaPorId(idSelecionado);

        bool conseguiuExcluir = repositorioRevistas.ExcluirRevista(idSelecionado);
        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Houve um erro durante a exclusão da revista", ConsoleColor.Red);
            return;
        }
        Notificador.ExibirMensagem("Revista excluída com sucesso", ConsoleColor.Green);
    }

    public void VisualizarRevista(bool mostrarRevistas)
    {
        if (mostrarRevistas == false)
        {
            MostrarCabecalho();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nVisualizando revistas...");
            Console.WriteLine("-----------------------------------\n");
            Console.ResetColor();
        }

        mostrarRevistas = true;
        if (mostrarRevistas == true)
        {
            Console.WriteLine(
            "{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -15} | {5, -15}",
            "ID", "Título:", "N’ da Edição", "Ano da Publicação", "Status", "Caixa"
            );

            Revista[] revistasCadastradas = repositorioRevistas.SelecionarRevista();

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

            Notificador.ExibirMensagem("\nPressione ENTER para continuar...", ConsoleColor.Yellow);
        }
    }
    
    public void AlterarStatusRevista()
    {
        Console.Write("Digite o ID da revista: ");
        int idRevista = int.Parse(Console.ReadLine()!);

        Console.Write("Digite o novo status da revista (disponível, emprestada, reservada): ");
        string novoStatus = Console.ReadLine()!;

        Revista revista = repositorioRevistas.SelecionarRevistaPorId(idRevista);

        if (revista == null)
        {
            Console.WriteLine("Revista não encontrada.");
            return;
        }

        if (novoStatus == "disponível" || novoStatus == "emprestada" || novoStatus == "reservada")
        {
            revista.StatusRevista = novoStatus;
            Console.WriteLine($"Status da revista '{revista.Titulo}' alterado para '{novoStatus}'.");
        }
        else
        {
            Console.WriteLine("Status inválido. Use: 'disponível', 'emprestada' ou 'reservada'.");
        }
    }    

    public Revista ObterDadosRevista()
    {
        string statusRevista = "Disponível";

        Console.Write("Digite o nome da revista: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o número da edição: ");
        string edicao = Console.ReadLine()!;

        Console.Write("Digite o ano da publicação da revista: ");
        string anoPublicacao = Console.ReadLine()!;

        Console.WriteLine("\nCaixas disponíveis:");
        Caixa[] caixas = repositorioCaixas.SelecionarCaixa();
        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa c = caixas[i];
            if (c == null) continue;
            Console.WriteLine($"{c.Id} - {c.Etiqueta}");
        }
        Console.Write("Selecione o ID da caixa: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());

        Caixa caixaSelecionada = repositorioCaixas.SelecionarCaixaPorId(idCaixa);
        if (caixaSelecionada == null)
        {
            Notificador.ExibirMensagem("Caixa não encontrada", ConsoleColor.Red);

            Caixa caixaPadrao = RepositorioCaixa.CaixaPadrao;

            Notificador.ExibirMensagem($"Caixa padrão: {caixaPadrao.Etiqueta}", ConsoleColor.Yellow);

            caixaSelecionada = caixaPadrao;
        }

        Revista novaRevista = new Revista(nome, edicao, anoPublicacao, statusRevista, caixaSelecionada);

        return novaRevista;

    }
}
