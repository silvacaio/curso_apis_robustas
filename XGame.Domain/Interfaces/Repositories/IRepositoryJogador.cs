using System;
using System.Collections.Generic;
using XGame.Domain.Entities;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        Jogador AutenticarJogador(string email, string senha);
        Jogador AdicionarJogador(Jogador jogador);
        Jogador ObterPorId(Guid jogador);
        IEnumerable<Jogador> Listar();
        void Alterar(Jogador jogador);
    }
}
