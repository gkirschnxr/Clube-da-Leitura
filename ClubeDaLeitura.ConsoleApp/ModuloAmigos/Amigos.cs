using ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;
public class Amigos
{
    public string Nome;
    public string Responsavel;
    public string Telefone;
    public Emprestimos[] Emprestimos;


    public Amigos(string nome, string responsavel, string telefone)
    {
        Nome = nome;
        Responsavel = responsavel;
        Telefone = telefone;
    }

    public string Validar()
    {
        string erros = "";

        if (string.IsNullOrEmpty(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";

        if (string.IsNullOrEmpty(Responsavel))
            erros += "O campo 'Responsável' é obrigatório.\n";

        if (Telefone.Length < 12)
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
