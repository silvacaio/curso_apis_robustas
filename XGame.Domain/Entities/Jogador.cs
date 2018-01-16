using System;
using XGame.Domain.Enums;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador
    {
        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public string Senha { get; set; }
        public EnumStatusJogador Status { get; set; }
    }
}
