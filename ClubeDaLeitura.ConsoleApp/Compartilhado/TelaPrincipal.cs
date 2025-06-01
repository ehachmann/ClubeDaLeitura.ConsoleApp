﻿using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class TelaPrincipal
    {
        private char opcaoEscolhida;

        private RepositorioAmigo repositorioAmigo;
        private RepositorioCaixa repositorioCaixa;

        private TelaAmigo telaAmigo;
        private TelaCaixa telaCaixa;


        public TelaPrincipal()
        {
            repositorioAmigo = new RepositorioAmigo();
            repositorioCaixa = new RepositorioCaixa();

            telaAmigo = new TelaAmigo(repositorioAmigo);
            telaCaixa = new TelaCaixa(repositorioCaixa);

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

            /*else if (opcaoEscolhida == '3')
                return telaFabricante;*/

            return null;
        }
    }
}

