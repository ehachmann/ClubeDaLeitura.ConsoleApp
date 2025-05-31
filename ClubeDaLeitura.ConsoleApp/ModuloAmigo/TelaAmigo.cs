using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo : TelaBase
{
    private RepositorioAmigo repositorioAmigo;

    public TelaAmigo(RepositorioAmigo repositorioAmigo)
        : base("Amigo", repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Amigos");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
            "Id", "Nome", "Responsavel", "Telefone"
        );

        EntidadeBase[] amigos = repositorioAmigo.SelecionarRegistros();

        for (int i = 0; i < amigos.Length; i++)
        {
            Amigo f = (Amigo)amigos[i];

            if (f == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                f.id, f.nome, f.responsavel, f.telefone
            );
        }

        Console.ReadLine();
    }

    protected override Amigo ObterDados()
    {
        Console.Write("Digite o nome do amigo: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o nome do responsável: ");
        string responsavel = Console.ReadLine();

        Console.Write("Digite o telefone do amigo: ");
        string telefone = Console.ReadLine();

        Amigo amigo = new Amigo(nome, responsavel, telefone);

        return amigo;
    }
}