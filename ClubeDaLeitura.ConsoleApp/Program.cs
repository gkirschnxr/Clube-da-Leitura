using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;

namespace ClubeDaLeitura.ConsoleApp;
public class Program
{
    static void Main(string[] args)
    {
        TelaPrincipal telaPrincipal = new TelaPrincipal();

        while (true)
        {
            char opcaoPrincipal = telaPrincipal.MenuPrincipal();

            if (opcaoPrincipal == '1') // Amigos
            {
                char opcaoEscolhida = '2';

                switch (opcaoEscolhida)
                {
                    case '2': 
                        TelaAmigos telaAmigos = new TelaAmigos();
                        telaAmigos.ExibirMenu();
                        break;
                }
                   
            }

            if (opcaoPrincipal == '2') // Caixas
            {
                char opcaoEscolhida = '2';

                switch (opcaoEscolhida)
                {
                    case '2':
                        TelaAmigos telaAmigos = new TelaAmigos();
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
                        TelaAmigos telaAmigos = new TelaAmigos();
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
                        TelaAmigos telaAmigos = new TelaAmigos();
                        telaAmigos.ExibirMenu();
                        break;
                }

            }
        }






        Console.ReadLine();
    }
}
