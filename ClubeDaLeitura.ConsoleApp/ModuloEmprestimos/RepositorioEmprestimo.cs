using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
public class RepositorioEmprestimo
{
    public Emprestimo[] emprestimos = new Emprestimo[100];
    public int contadorEmprestimos = 0;
    public void CadastrarEmprestimo(Emprestimo novoEmprestimo)
    {
        novoEmprestimo.Id = GeradorDeIDs.GerarIdEmprestimos();
        emprestimos[contadorEmprestimos++] = novoEmprestimo;
    }

    public Emprestimo[] SelecionarEmprestimo()
    {
        return emprestimos;
    }

    public Emprestimo SelecionarEmprestimoPorId(int idEmprestimo)
    {
        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo e = emprestimos[i];
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
            Emprestimo e = emprestimos[i];
            if (e == null)
                continue;
            else if (e.StatusEmprestimo == "Aberto")
                e.StatusEmprestimo = "Fechado";
        }
    }

    public void VisualizarEmprestimos()
    {

    }
}
