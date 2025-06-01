using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class Emprestimo : EntidadeBase
{
    public string amigo;
    public string revista;
    public DateTime dataEmprestimo;
    public DateTime dataDevolucao;

    public Emprestimo(string amigo, string revista, DateTime dataEmprestimo, DateTime dataDevolucao)
    {
        this.amigo = amigo;
        this.revista = revista;
        this.dataEmprestimo = dataEmprestimo;
        this.dataDevolucao = dataDevolucao;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(amigo))
            erros += "O campo amigo é obrigatório!\n";

        else if (amigo.Length < 3)
            erros += "O nome deve conter mais que 2 caracteres!\n";

        //if (responsavel.Length < 4)
        //erros += "O nome do responsável deve conter mais que 3 caracteres!\n";

        //if (diasEmprestimo > 7)
        //erros += "O prazo máximo para empréstimo é 7 dias!\n";

        return erros;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Emprestimo emprestimoAtualizado = (Emprestimo)registroAtualizado;

        this.amigo = emprestimoAtualizado.amigo;
        this.revista = emprestimoAtualizado.revista;
        this.dataEmprestimo = emprestimoAtualizado.dataEmprestimo;
        this.dataDevolucao = emprestimoAtualizado.dataDevolucao;
    }
}
