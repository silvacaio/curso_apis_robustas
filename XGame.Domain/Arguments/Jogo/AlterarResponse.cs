using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogo
{
    public class AlterarResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator AlterarResponse(Entities.Jogo entidade)
        {
            return new AlterarResponse()
            {
                Id = entidade.Id,
                Message = Resources.Message.OPERACAO_SUCESSO
            };
        }
    }
}
