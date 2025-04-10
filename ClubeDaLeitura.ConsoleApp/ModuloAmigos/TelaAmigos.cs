namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;
class TelaAmigos
{
    public char ExibirMenu()
    {
        MostrarCabecalho();

        Console.WriteLine("1 - Registrar novo amigo :)");
        Console.WriteLine("2 - Editar cadastro do amigo :p");
        Console.WriteLine("3 - Excluir amigo :(");
        Console.WriteLine("4 - Visualizar amigos");
        Console.WriteLine("5 - Visualizar empréstimos do amigo");

        Console.WriteLine("\nS - Voltar");

        Console.Write("Escolha uma opção: ");
        char opcaoEscolhida = Console.ReadLine()![0];

        return opcaoEscolhida;
    }

    public void MostrarCabecalho()
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("|   Clube da Leitura do Gustavo   |");
        Console.WriteLine("-----------------------------------\n");
    }
}
