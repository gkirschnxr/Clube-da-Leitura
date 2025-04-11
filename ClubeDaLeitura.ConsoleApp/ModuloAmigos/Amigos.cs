using ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;
public class Amigos
{
    public int Id;
    public string Nome;
    public string Responsavel;
    public string Telefone;
    public Emprestimos[] Emprestimos;


    public Amigos(string nome, string responsavel, string telefone) // ,Emprestimos emprestimos)
    {
        Nome = nome;
        Responsavel = responsavel;
        Telefone = telefone;
        // Emprestimos = emprestimos;

    }

    public string Validar()
    {
        string erros = "";

        if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo 'Nome' deve contar no mínimo 3 letras.\n";

        if (Responsavel.Length < 3 || Responsavel.Length > 100)
            erros += "O campo 'Responsavel' deve contar no mínimo 3 letras.\n";

        if (Telefone.Length < 10)
            erros += "O campo 'Telefone' deve seguir o formato (XX) XXXX-XXXX.\n";

        return erros;
    }

    public int ObterEmprestimos()
    {
        int contador = 0;

        for (int i = 0; i < Emprestimos.Length; i++)
        {
            if (Emprestimos[i] != null)
                contador++;
        }

        return contador;
    }


}
