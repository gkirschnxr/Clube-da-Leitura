using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;
public class RepositorioCaixa
{
    public Caixa[] caixas = new Caixa[100];
    public int contadorCaixas = 0;

    public static Caixa CaixaPadrao = new Caixa("Padrão", "15", DateTime.Now.AddDays(7));

    public RepositorioCaixa()
    {
        CaixaPadrao.Id = GeradorDeIDs.GerarIdCaixas();
        caixas[contadorCaixas++] = CaixaPadrao;
    }

    public void CadastrarCaixa(Caixa novaCaixa, string erros)
    {
        foreach (Caixa caixa in caixas)
        {
            if (caixa != null && caixa.Etiqueta == novaCaixa.Etiqueta)
            {
                erros += "Já existe uma etiqueta com esse nome";
                break;
            }
            else
            {
                novaCaixa.Id = GeradorDeIDs.GerarIdCaixas();
                caixas[contadorCaixas++] = novaCaixa;
                break;
            }
        }
    }
    public bool EditarCaixa(int idCaixa, Caixa editarCaixa)
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

    public Caixa[] SelecionarCaixa()
    {
        return caixas;
    }

    public Caixa SelecionarCaixaPorId(int idCaixa)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa c = caixas[i];

            if (c == null) continue;

            else if (c.Id == idCaixa) return c;
        }
        return null!;
    }



}
