using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo : TelaBase
{
    private RepositorioEmprestimo repositorioEmprestimo;

    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo)
       :  base("Emprestimo", repositorioEmprestimo)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Emprestimos");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -20} | {4, -15}",
            "Id", "Amigo", "Revista", "Data do Empréstimo", "Data de Devolução"
        );

        EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarRegistros();

        for (int i = 0; i < emprestimos.Length; i++)
        {
            Emprestimo E = (Emprestimo)emprestimos[i];

            if (E == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -20} | {4, -15}",
                E.Id, E.amigo, E.revista, E.dataEmprestimo.ToShortDateString(), E.dataDevolucao.ToShortDateString()
            );
        }

        Console.ReadLine();
    }

    protected override Emprestimo ObterDados()
    {
        Console.Write("Digite o nome do amigo: ");
        string amigo = Console.ReadLine();

        Console.Write("Digite o nome da revista: ");
        string revista = Console.ReadLine();

        DateTime dataEmprestimo = DateTime.Now;

        DateTime dataDevolucao = DateTime.Today;  

        Emprestimo emprestimo = new Emprestimo(amigo, revista, dataEmprestimo, dataDevolucao);

        return emprestimo;
    }
}