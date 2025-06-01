using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class TelaPrincipal
    {
        private char opcaoEscolhida;

        private RepositorioAmigo repositorioAmigo;
        private RepositorioCaixa repositorioCaixa;
        private RepositorioRevista repositorioRevista;
        private RepositorioEmprestimo repositorioEmprestimo;

        private TelaAmigo telaAmigo;
        private TelaCaixa telaCaixa;
        private TelaRevista telaRevista;
        private TelaEmprestimo telaEmprestimo;


        public TelaPrincipal()
        {
            repositorioAmigo = new RepositorioAmigo();
            repositorioCaixa = new RepositorioCaixa();
            repositorioRevista = new RepositorioRevista();
            repositorioEmprestimo = new RepositorioEmprestimo();

            telaCaixa = new TelaCaixa(repositorioCaixa);
            telaAmigo = new TelaAmigo(repositorioAmigo);

            telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo);
            telaRevista = new TelaRevista(repositorioRevista,repositorioCaixa);
        }

        public void ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|          Clube da Leitura            |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Controle de Amigos");
            Console.WriteLine("2 - Controle de Caixas");
            Console.WriteLine("3 - Controle de Revistas");
            Console.WriteLine("4 - Controle de Empréstimos");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            opcaoEscolhida = Console.ReadLine()[0];
        }

        public TelaBase ObterTela()
        {
            if (opcaoEscolhida == '1')
                return telaAmigo;

            else if (opcaoEscolhida == '2')
                return telaCaixa;

            else if (opcaoEscolhida == '3')
                return telaRevista;

            else if (opcaoEscolhida == '4')
                return telaEmprestimo;

            return null;
        }
    }
}

