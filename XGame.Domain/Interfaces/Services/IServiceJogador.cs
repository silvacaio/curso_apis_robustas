using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogador;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServiceJogador
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);
        AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorResquest request);
        AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request);
        IEnumerable<JogadorResponse> ListarJogadores();
        ResponseBase Remover(Guid id);
    }
}
