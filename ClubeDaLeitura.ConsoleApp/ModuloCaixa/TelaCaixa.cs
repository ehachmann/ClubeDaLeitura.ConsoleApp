using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class TelaCaixa : TelaBase
{
    private RepositorioCaixa repositorioCaixa;

    public TelaCaixa(RepositorioCaixa repositorioCaixa)
        : base("Caixa", repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Caixas");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
            "Id", "Etiqueta", "Cor", "Dias de Empréstimo"
        );

        EntidadeBase[] caixas = repositorioCaixa.SelecionarRegistros();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa C = (Caixa)caixas[i];

            if (C == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                C.id, C.etiqueta, C.cor, C.diasEmprestimo
            );
        }

        Console.ReadLine();
    }

    protected override Caixa ObterDados()
    {
        Console.Write("Digite o nome da Etiqueta: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a cor da Caixa: ");
        string cor = Console.ReadLine();

        Console.Write("Digite quantidade de dias de empréstimo: ");
        int dias = int.Parse(Console.ReadLine());

        Caixa caixa = new Caixa(nome, cor, dias);

        return caixa;
    }
}