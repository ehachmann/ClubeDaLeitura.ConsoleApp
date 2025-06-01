using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

public class Caixa : EntidadeBase
{
    public string etiqueta;
    public string cor;
    public int diasEmprestimo;

    public Caixa(string etiqueta, string cor, int diasEmprestimo)
    {
        this.etiqueta = etiqueta;
        this.cor = cor;
        this.diasEmprestimo = diasEmprestimo;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(etiqueta))
            erros += "O campo etiqueta é obrigatório!\n";

        else if (etiqueta.Length < 4)
            erros += "O nome deve conter mais que 3 caracteres!\n";

        //if (responsavel.Length < 4)
            //erros += "O nome do responsável deve conter mais que 3 caracteres!\n";

        if (diasEmprestimo > 7)
            erros += "O prazo máximo para empréstimo é 7 dias!\n";

        return erros;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Caixa caixaAtualizada = (Caixa)registroAtualizado;

        this.etiqueta = caixaAtualizada.etiqueta;
        this.cor = caixaAtualizada.cor;
        this.diasEmprestimo = caixaAtualizada.diasEmprestimo;
    }
}
