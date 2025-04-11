namespace ClubeDaLeitura.ConsoleApp.Compartilhado;
class TelaPrincipal
{
    public char MenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("\nBem vindo ao Clube da Leitura do Gustavo!\n");

        Console.WriteLine("O que deseja fazer hoje? \n");

        Console.WriteLine("\t1 - Gerenciar Amigos");
        Console.WriteLine("\t2 - Gerenciar Caixas");
        Console.WriteLine("\t3 - Gerenciar Revistas");
        Console.WriteLine("\t4 - Gerenciar Empréstimos");

        Console.Write("\nSelecione uma das opções acima: ");
        char opcaoEscolhida = Console.ReadLine()![0]; //nao fechar programa ao digitar zzero

        return opcaoEscolhida;
    }
}
