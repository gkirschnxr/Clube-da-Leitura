﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp;
public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        RepositorioAmigos repositorioAmigos = new RepositorioAmigos();
        RepositorioCaixas repositorioCaixas = new RepositorioCaixas();


        TelaAmigos telaAmigos = new TelaAmigos(repositorioAmigos);
        TelaCaixas telaCaixas = new TelaCaixas(repositorioCaixas);

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
