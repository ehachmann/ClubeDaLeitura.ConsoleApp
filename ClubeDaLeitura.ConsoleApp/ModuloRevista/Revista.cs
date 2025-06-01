using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class Revista : EntidadeBase
{
    public int id;
    public string titulo;
    public int numeroEdicao;
    public DateTime anoPublicacao;
    public string caixa;

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Revista revistaAtualizada = (Revista)registroAtualizado;

        this.titulo = revistaAtualizada.titulo;
        this.numeroEdicao = revistaAtualizada.numeroEdicao;
        this.anoPublicacao = revistaAtualizada.anoPublicacao;
        this.caixa = revistaAtualizada.caixa;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(titulo))
            erros += "O campo \"Título\" é obrigatório.\n";

        else if (titulo.Length < 3)
            erros += "O campo \"Título\" precisa conter ao menos 2 caracteres.\n";

        if (numeroEdicao > 0)
            erros += "O campo \"Número da Edição\" deve ser maior que zero.\n";

        /*if (anoPublicacao > DateTime.Now)
            erros += "O campo \"\" deve conter uma data passada.\n";*/

        return erros;
    }
}