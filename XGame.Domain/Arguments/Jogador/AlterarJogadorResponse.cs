using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator AlterarJogadorResponse(Entities.Jogador entidade)
        {
            return new AlterarJogadorResponse()
            {
                Id = entidade.Id,
                Message = Resources.Message.OPERACAO_SUCESSO
            };
        }
    }
}
