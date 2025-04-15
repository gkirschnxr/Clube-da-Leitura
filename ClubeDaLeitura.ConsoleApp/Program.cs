using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp;
public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        RepositorioAmigo repositorioAmigos = new RepositorioAmigo();
        RepositorioCaixa repositorioCaixas = new RepositorioCaixa();
        RepositorioRevista repositorioRevistas = new RepositorioRevista();
        RepositorioEmprestimo repositorioEmprestimos = new RepositorioEmprestimo();


        TelaAmigos telaAmigos = new TelaAmigos(repositorioAmigos);
        TelaCaixas telaCaixas = new TelaCaixas(repositorioCaixas);
        TelaRevistas telaRevistas = new TelaRevistas(repositorioRevistas, repositorioCaixas);
        TelaEmprestimo telaEmprestimos = new TelaEmprestimo(repositorioEmprestimos, repositorioAmigos, repositorioRevistas, repositorioCaixas);

        TelaPrincipal telaPrincipal = new TelaPrincipal();

        while (true)
        {
            char opcaoPrincipal = telaPrincipal.MenuPrincipal();

            if (opcaoPrincipal == '1') // Amigos
            {
                char opcaoEscolhida = telaAmigos.ExibirMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaAmigos.RegistrarAmigo(); break;

                    case '2': telaAmigos.EditarAmigo(); break;

                    case '3': telaAmigos.ExcluirAmigo(); break;

                    case '4': telaAmigos.VisualizarAmigos(false); break;

                    case '5': telaAmigos.EmprestimosAmigo(); break; // fazer o metodo, puxar emprestimos??
                }
                   
            }

            if (opcaoPrincipal == '2') // Caixas
            {
                char opcaoEscolhida = telaCaixas.ExibirMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaCaixas.RegistrarCaixa(); break;

                    case '2': telaCaixas.EditarCaixa(); break;

                    case '3': telaCaixas.ExcluirCaixa(); break;

                    case '4': telaCaixas.VisualizarCaixas(false); break;
                }

            }

            if (opcaoPrincipal == '3') // Revistas
            {
                char opcaoEscolhida = telaRevistas.ExibirMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaRevistas.RegistrarRevista(); break;

                    case '2': telaRevistas.EditarRevista(); break;

                    case '3': telaRevistas.ExcluirRevista(); break;

                    case '4': telaRevistas.VisualizarRevista(false); break;

                    case '5': telaRevistas.AlterarStatusRevista(); break;
                }

            }

            if (opcaoPrincipal == '4') // Empréstimos
            {
                char opcaoEscolhida = telaEmprestimos.ExibirMenu();

                switch (opcaoEscolhida)
                {
                    case '1': telaEmprestimos.RegistrarEmprestimo(); break;

                    case '2': telaEmprestimos.DevolucaoEmprestimo(); break;

                    case '3': telaEmprestimos.VisualizarEmprestimo(false); break;
                }

            }
        }
    }
}
