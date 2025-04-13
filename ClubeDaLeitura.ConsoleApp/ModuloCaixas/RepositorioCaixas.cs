
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;
public class RepositorioCaixas
{
    public Caixas[] caixas = new Caixas[100];
    public int contadorCaixas = 0;
    public void CadastrarCaixa(Caixas novaCaixa)
    {
        novaCaixa.Id = GeradorDeIDs.GerarIdCaixas();

        caixas[contadorCaixas++] = novaCaixa;
    }
    public bool EditarCaixa(int idCaixa, Caixas editarCaixa)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] == null!) continue;

            else if (caixas[i].Id == idCaixa)
            {
                caixas[i].Etiqueta = editarCaixa.Etiqueta;
                caixas[i].Cor = editarCaixa.Cor;
                caixas[i].Dias = editarCaixa.Dias;

                return true;
            }
        }
        return false;
    }

    public bool ExcluirCaixa(int idCaixa)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] == null!) continue;

            else if (caixas[i].Id == idCaixa) caixas[i] = null!;
            return true;
        }
        return false;
    }

    public Caixas[] SelecionarCaixa()
    {
        return caixas;
    }

    public Caixas SelecionarCaixaPorId(int idCaixa)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            Caixas c = caixas[i];

            if (c == null) continue;

            else if (c.Id == idCaixa) return c;
        }
        return null!;
    }


}
