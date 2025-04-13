﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

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

        repositorioCaixas.CadastrarCaixa(novaCaixa, erros);

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem("Houve um erro durante o registro da Caixa", ConsoleColor.Red);

            RegistrarCaixa();

            return;
        }

        // nao consigo fazer aparecer a mensagem de erro ao digitar o mesmo nome na etiqueta :( so bad
        Notificador.ExibirMensagem("Caixa adicionada com sucesso!", ConsoleColor.Green);
    }

    public void EditarCaixa()
    {
        MostrarCabecalho();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nEditando caixa...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        Console.Write("Digite o ID da caixa que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Caixas caixaEditada = ObterDadosCaixa();

        bool conseguiuEditar = repositorioCaixas.EditarCaixa(idSelecionado, caixaEditada);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição da caixa", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("Caixa editada com sucesso", ConsoleColor.Green);
    }

    public bool ExcluirCaixa()
    {
        MostrarCabecalho();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nExcluindo caixa...");
        Console.WriteLine("-----------------------------------\n");
        Console.ResetColor();

        VisualizarCaixas(true);
    

        Console.Write("Digite o ID do amigo que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Caixas caixaExcluida = repositorioCaixas.SelecionarCaixaPorId(idSelecionado);

        bool conseguiuExcluir = repositorioCaixas.ExcluirCaixa(idSelecionado);

        if (caixaExcluida == null || PossuiRevistasVinculadas(idSelecionado))
        {
            Notificador.ExibirMensagem("Caixa não encontrada ou possui revistas vinculadas", ConsoleColor.Red);
            return false;
        }

        Notificador.ExibirMensagem("Caixa excluída com sucesso", ConsoleColor.Green);
        return true;
    }

    public void VisualizarCaixas(bool mostrarCaixas)
    {
        if (mostrarCaixas == false)
        {
            MostrarCabecalho();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nVisualizando caixas...");
            Console.WriteLine("-----------------------------------\n");
            Console.ResetColor();
        }

        mostrarCaixas = true;
        if (mostrarCaixas == true)
        {
            Console.WriteLine(
            "{0, -5} | {1, -20} | {2, -20} | {3, -15}",
            "ID", "Etiqueta:", "N’ da Cor", "Dias de Empréstimo" // "Possui Empréstimos?"
            );

            Caixas[] caixasCadastradas = repositorioCaixas.SelecionarCaixa();

            for (int i = 0; i < caixasCadastradas.Length; i++)
            {
                Caixas c = caixasCadastradas[i];

                if (c == null) continue;

                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), c.Cor);
                Console.WriteLine(
                    "{0, -5} | {1, -20} | {2, -20} | {3, -15}",
                    c.Id, c.Etiqueta, c.Cor, c.Dias
                    );
                Console.ResetColor();
            }

            Notificador.ExibirMensagem("\nPressione ENTER para continuar...", ConsoleColor.Yellow);
        }
    }

    public Caixas ObterDadosCaixa()
    {
        Console.Write("Digite a etiqueta da caixa: ");
        string etiqueta = Console.ReadLine()!;

        Console.Write("Qual será a cor da caixa? ");
        ConsoleColor[] cores = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        for (int i = 0; i < cores.Length; i++)
        {
            Console.ForegroundColor = cores[i];
            Console.WriteLine($"{i}: {cores[i]}");
        }

        Console.ResetColor();
        Console.Write("Selecione o número da cor ");
        string corInput = Console.ReadLine()!;

        if (int.TryParse(corInput, out int escolha) && escolha >= 0 && escolha < cores.Length)
        {
            ConsoleColor corEscolhida = cores[escolha];

            Console.ForegroundColor = corEscolhida;
            Console.WriteLine($"\nVocê escolheu: {corEscolhida}");
            Console.ResetColor();

        }
        else Console.WriteLine("Escolha inválida.");

        Console.Write("Digite os dias de empréstimo da caixa (pressione ENTER para usar o padrão de 7 dias): ");
        string diasEmprestimo = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(diasEmprestimo))
        {
            diasEmprestimo = "7";
            Console.WriteLine("Nenhum valor inserido. O prazo padrão de 7 dias foi atribuído.");
        }

        Caixas caixa = new Caixas(etiqueta, corInput, diasEmprestimo);

        return caixa;
    }
    public bool PossuiRevistasVinculadas(int idCaixa)
    {
        // Aqui você deve implementar a lógica para verificar se há revistas associadas à caixa
        // Exemplo: Verificar em uma lista de revistas se alguma está vinculada à caixa
        return false; // Substitua pela lógica real
    }
}
