using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class Amigo : EntidadeBase
    {
        public string nome;
        public string responsavel;
        public string telefone;

        public Amigo(string nome, string responsavel, string telefone)
        {
            this.nome = nome;
            this.responsavel = responsavel;
            this.telefone = telefone;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(nome))
                erros += "O nome é obrigatório!\n";

            else if (nome.Length < 4)
                erros += "O nome deve conter mais que 3 caracteres!\n";

            if (responsavel.Length < 4)
                erros += "O nome do responsável deve conter mais que 3 caracteres!\n";

            if (string.IsNullOrWhiteSpace(telefone))
                erros += "O telefone é obrigatório!\n";

            else if (telefone.Length < 9)
                erros += "O telefone deve conter no mínimo 9 caracteres!\n";

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Amigo amigoAtualizado = (Amigo)registroAtualizado;

            this.nome = amigoAtualizado.nome;
            this.responsavel = amigoAtualizado.responsavel;
            this.telefone = amigoAtualizado.telefone;
        }
    }
}
