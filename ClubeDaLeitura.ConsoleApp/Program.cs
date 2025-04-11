using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;

namespace ClubeDaLeitura.ConsoleApp;
public class Program
{
    static void Main(string[] args)
    {
        RepositorioAmigos repositorioAmigos = new RepositorioAmigos();


        TelaAmigos telaAmigos = new TelaAmigos(repositorioAmigos);


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
                char opcaoEscolhida = '2';

                switch (opcaoEscolhida)
                {
                    case '2':
                        telaAmigos.ExibirMenu();
                        break;
                }

            }

            if (opcaoPrincipal == '3') // Revistas
            {
                char opcaoEscolhida = '2';

                switch (opcaoEscolhida)
                {
                    case '2':
                        telaAmigos.ExibirMenu();
                        break;
                }

            }

            if (opcaoPrincipal == '4') // Empréstimos
            {
                char opcaoEscolhida = '2';

                switch (opcaoEscolhida)
                {
                    case '2':
                        telaAmigos.ExibirMenu();
                        break;
                }

            }
        }






        Console.ReadLine();
    }
}
