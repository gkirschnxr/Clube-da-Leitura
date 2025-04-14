using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
public class RepositorioEmprestimos
{
    public Emprestimos[] emprestimos = new Emprestimos[100];
    public int contadorEmprestimos = 0;
    public void CadastrarEmprestimo(Emprestimos novoEmprestimo)
    {
        novoEmprestimo.Id = GeradorDeIDs.GerarIdEmprestimos();
        emprestimos[contadorEmprestimos++] = novoEmprestimo;
    }

    public Emprestimos[] SelecionarEmprestimo()
    {
        return emprestimos;
    }

    public Emprestimos SelecionarEmprestimoPorId(int idEmprestimo)
    {
        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimos e = emprestimos[i];
            if (e == null)
                continue;
            else if (e.Id == idEmprestimo)
                return e;
        }
        return null!;
    }

    public void DevolucaoEmprestimo()
    {
        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimos e = emprestimos[i];
            if (e == null)
                continue;
            else if (e.StatusEmprestimo == "Aberto")
                e.StatusEmprestimo = "Fechado";
        }
    }

    public void VisualizarEmprestimos()
}
