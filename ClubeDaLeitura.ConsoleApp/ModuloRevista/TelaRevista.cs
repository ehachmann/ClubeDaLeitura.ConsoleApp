using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class TelaRevista : TelaBase
{
    private RepositorioRevista repositorioRevista;
    private RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista)
           : base("Revista", repositorioRevista)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Revistas");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -30} | {2, -15} | {3, -15} | {4, -20}",
            "Id", "Título", "Número da Edição", "Ano de Publicação", "Caixa"
        );

        EntidadeBase[] revistas = repositorioRevista.SelecionarRegistros();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista r = (Revista)revistas[i];

            if (r == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -15} | {3, -15} | {4, -20}",
                r.id, r.titulo, r.numeroEdicao, r.anoPublicacao.ToShortDateString(), r.caixa
            );
        }

        Console.ReadLine();
    }

    public void VisualizarCaixas()
    {
        Console.WriteLine();

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

    protected override Revista ObterDados()
    {
        Console.Write("Digite o nome do título: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite o número da edição: ");
        int numeroEdicao = int.Parse(Console.ReadLine());

        Console.Write("Digite o ano de publicação: ");
        DateTime anoPublicacao = DateTime.Parse(Console.ReadLine());

        Console.Write("Digite o nome da etiqueta da caixa: ");
        string caixa = (Console.ReadLine());

        VisualizarCaixas();

        Console.Write("Digite o id da Caixa: ");
        int idCaixa = int.Parse(Console.ReadLine());

        Caixa caixaSelecionada = (Caixa)repositorioCaixa.SelecionarRegistroPorId(idCaixa);

        Revista revista = new Revista();
        revista.titulo = titulo;
        revista.numeroEdicao = numeroEdicao;
        revista.anoPublicacao = anoPublicacao;
        revista.caixa = caixa;

        return revista;
    }
}