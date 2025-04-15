
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;
public class RepositorioRevista
{
    public Revista[] revistas = new Revista[100];
    public int contadorRevistas = 0;

    public void CadastrarRevista(Revista novaRevista)
    {
        novaRevista.Id = GeradorDeIDs.GerarIdRevistas();

        revistas[contadorRevistas++] = novaRevista;
    }

    public bool EditarRevista(int idRevista, Revista editarRevista)
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

    public Revista SelecionarRevistaPorId(int idRevista)
    {
        for (int i = 0; i < revistas.Length; i++)
        {
            Revista r = revistas[i];

            if (r == null) continue;

            else if (r.Id == idRevista) return r;
        }
        return null!;
    }

    public Revista[] SelecionarRevista()
    {
        return revistas;
    }

    public Revista StatusRevista(int idRevista, string novoStatus)
    {
        Revista revista = SelecionarRevistaPorId(idRevista);

        if (novoStatus == "disponível" || novoStatus == "emprestada" || novoStatus == "reservada")
        {
            revista.StatusRevista = novoStatus;
            Console.WriteLine($"Status da revista '{revista.Titulo}' alterado para '{novoStatus}'.");
        }
        else
            Console.WriteLine("Status inválido. Use: 'disponível', 'emprestada' ou 'reservada'.");

        return revista;
    }
}
