using System;

namespace XGame.Domain.Arguments.Jogador
{
    public class AdicionarJogadorResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Mensagem { get; set; }
    }
}
