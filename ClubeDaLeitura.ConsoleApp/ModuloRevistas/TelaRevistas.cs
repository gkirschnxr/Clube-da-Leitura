using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;
public class TelaRevistas
{
    public RepositorioRevistas repositorioRevistas;
    public RepositorioCaixas repositorioCaixas;
    public TelaRevistas(RepositorioRevistas repositorioRevistas, RepositorioCaixas repositorioCaixas)
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

        Revistas novaRevista = ObterDadosRevista();

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

        Revistas revistaEditada = ObterDadosRevista();

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

        Revistas revistaExcluida = repositorioRevistas.SelecionarRevistaPorId(idSelecionado);

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

            Revistas[] revistasCadastradas = repositorioRevistas.SelecionarRevista();

            for (int i = 0; i < revistasCadastradas.Length; i++)
            {
                Revistas r = revistasCadastradas[i];

                if (r == null) continue;

                string nomeCaixa = r.Caixa.Length > 0 ? r.Caixa[0].Etiqueta : "Sem Caixa";

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

        Revistas revista = repositorioRevistas.SelecionarRevistaPorId(idRevista);

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

    public Revistas ObterDadosRevista()
    {
        string statusRevista = "Disponível";

        Console.Write("Digite o nome da revista: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o número da edição: ");
        string edicao = Console.ReadLine()!;

        Console.Write("Digite o ano da publicação da revista: ");
        string anoPublicacao = Console.ReadLine()!;

        Console.WriteLine("\nCaixas disponíveis:");
        Caixas[] caixas = repositorioCaixas.SelecionarCaixa();
        for (int i = 0; i < caixas.Length; i++)
        {
            Caixas c = caixas[i];
            if (c == null) continue;
            Console.WriteLine($"{c.Id} - {c.Etiqueta}");
        }
        Console.Write("Selecione o ID da caixa: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());

        Caixas caixaSelecionada = repositorioCaixas.SelecionarCaixaPorId(idCaixa);
        if (caixaSelecionada == null)
        {
            Notificador.ExibirMensagem("Caixa não encontrada", ConsoleColor.Red);

            Caixas caixaPadrao = RepositorioCaixas.CaixaPadrao;

            Notificador.ExibirMensagem($"Caixa padrão: {caixaPadrao.Etiqueta}", ConsoleColor.Yellow);
        }

        Revistas novaRevista = new Revistas(nome, edicao, anoPublicacao, statusRevista, new Caixas[] { caixaSelecionada });

        return novaRevista;

    }
}
