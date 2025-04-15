
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos;
public class RepositorioAmigo
{
    public Amigo[] amigos = new Amigo[100];
    public int contadorAmigos = 0;

    public void CadastrarAmigo(Amigo novoAmigo)
    {
        novoAmigo.Id = GeradorDeIDs.GerarIdAmigos();

        amigos[contadorAmigos++] = novoAmigo;
    }

    public bool EditarAmigo(int idAmigo, Amigo editarAmigo)
    {
        for (int i = 0; i < amigos.Length; i++)
        {
            if (amigos[i] == null) continue;

            else if (amigos[i].Id == idAmigo)
            {
                amigos[i].Nome = editarAmigo.Nome;
                amigos[i].Responsavel = editarAmigo.Responsavel;
                amigos[i].Telefone = editarAmigo.Telefone;

                return true;
            }
        }

        return false;
    }

    public Amigo[] SelecionarAmigo()
    {
        return amigos;
    }

    public Amigo SelecionarAmigoPorId(int idAmigo)
    {
        for (int i = 0; i < amigos.Length; i++)
        {
            Amigo a = amigos[i];

            if (a == null)
                continue;

            else if (a.Id == idAmigo)
                return a;
        }

        return null!;
    }

    public bool ExcluirAmigo(int idAmigo)
    {
        for (int i = 0; i < amigos.Length; i++)
        {
            if (amigos[i] == null) continue;

            else if (amigos[i].Id == idAmigo)
            {
                amigos[i] = null!;

                return true;
            }
        }

        return false;
    }

}
