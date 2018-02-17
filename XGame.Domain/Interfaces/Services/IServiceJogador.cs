using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogador;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServiceJogador : IServiceBase
    {
        AutenticarJogadorResponse Autenticar(AutenticarJogadorRequest request);
        AdicionarJogadorResponse Adicionar(AdicionarJogadorResquest request);
        AlterarJogadorResponse Alterar(AlterarJogadorRequest request);
        IEnumerable<JogadorResponse> Listar();
        ResponseBase Remover(Guid id);
    }
}
