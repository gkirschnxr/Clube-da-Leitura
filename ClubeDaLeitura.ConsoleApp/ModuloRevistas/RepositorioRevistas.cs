
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;
public class RepositorioRevistas
{
    public Revistas[] revistas = new Revistas[100];
    public int contadorRevistas = 0;

    public void CadastrarRevista(Revistas novaRevista)
    {
        novaRevista.Id = GeradorDeIDs.GerarIdRevistas();

        revistas[contadorRevistas++] = novaRevista;
    }

    public bool EditarRevista(int idRevista, Revistas editarRevista)
    {
        for (int i = 0; i < revistas.Length; i++)
        {
            if (revistas[i] == null!) continue;

            else if (revistas[i].Id == idRevista)
            {
                revistas[i].Titulo = editarRevista.Titulo;
                revistas[i].Edicao = editarRevista.Edicao;
                revistas[i].AnoPublicacao = editarRevista.AnoPublicacao;

                return true;
            }
        }
        return false;
    }

    public bool ExcluirRevista(int idRevista)
    {
        for (int i = 0; i < revistas.Length; i++)
        {
            if (revistas[i] == null!) continue;

            else if (revistas[i].Id == idRevista) revistas[i] = null!;
            return true;
        }
        return false;
    }

    public Revistas SelecionarRevistaPorId(int idRevista)
    {
        for (int i = 0; i < revistas.Length; i++)
        {
            Revistas r = revistas[i];

            if (r == null) continue;

            else if (r.Id == idRevista) return r;
        }
        return null!;
    }

    public Revistas[] SelecionarRevista()
    {
        return revistas;
    }

    public Revistas StatusRevista(int idRevista, string novoStatus)
    {
        Revistas revista = SelecionarRevistaPorId(idRevista);
        if (revista == null)
           Console.WriteLine("Revista não encontrada.");

        if (novoStatus == "disponível" || novoStatus == "emprestada" || novoStatus == "reservada")
        {
            revista.StatusRevista = novoStatus;
            Console.WriteLine($"Status da revista '{revista.Titulo}' alterado para '{novoStatus}'.");
        }
        else
        {
            Console.WriteLine("Status inválido. Use: 'disponível', 'emprestada' ou 'reservada'.");
        }

        return revista;
    }
}
