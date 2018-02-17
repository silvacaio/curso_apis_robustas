using System;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogo
{
    public class AdicionarResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator AdicionarResponse(Entities.Jogo entidade)
        {
            return new AdicionarResponse()
            {
                Id = entidade.Id,
                Message = XGame.Domain.Resources.Message.OPERACAO_SUCESSO
            };
        }
    }

}
