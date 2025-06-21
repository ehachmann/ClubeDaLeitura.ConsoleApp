﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva;

public class Reserva : EntidadeBase
{
    public Amigo Amigo { get; set; }
    public Revista Revista { get; set; }
    public DateTime DataAbertura { get; set; }
    public bool EstaAtiva { get; set; }

    public Reserva(Amigo amigo, Revista revista)
    {
        Amigo = amigo;
        Revista = revista;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Reserva reservaAtualizada = (Reserva)registroAtualizado;

        Amigo = reservaAtualizada.Amigo;
        Revista = reservaAtualizada.Revista;
    }

    public override string Validar()
    {
        string erros = string.Empty;

        if (Amigo == null)
            erros += "O campo \"Amigo\" é obrigatório.";

        if (Revista == null)
            erros += "O campo \"Revista\" é obrigatório.";

        return erros;
    }

    public void Iniciar()
    {
        Revista.Status = "Reservada";

        DataAbertura = DateTime.Now;
        EstaAtiva = true;
    }

    public void Concluir()
    {
        Revista.Status = "Disponível";

        EstaAtiva = false;
    }
}