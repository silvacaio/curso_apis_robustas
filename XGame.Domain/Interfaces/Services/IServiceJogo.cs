using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogo;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServiceJogo : IServiceBase
    {
        AdicionarResponse Adicionar(AdicionarRequest request);
        AlterarResponse Alterar(AlterarRequest request);
        IEnumerable<JogoResponse> Listar();
        ResponseBase Remover(Guid id);
    }
}
