namespace ClubeDaLeitura.ConsoleApp.Compartilhado;
class TelaPrincipal
{
    public char MenuPrincipal()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║       Bem vindo ao Clube da Leitura do Gustavo   ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝");
        Console.ResetColor();

        Console.WriteLine("\nO que deseja fazer hoje?\n");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  [1] Gerenciar Amigos");
        Console.WriteLine("  [2] Gerenciar Caixas");
        Console.WriteLine("  [3] Gerenciar Revistas");
        Console.WriteLine("  [4] Gerenciar Empréstimos");
        Console.ResetColor();

        Console.Write("\nSelecione uma das opções acima: ");
        string entrada = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(entrada))
            return ' ';

        return char.ToUpper(entrada[0]);
    }
}
