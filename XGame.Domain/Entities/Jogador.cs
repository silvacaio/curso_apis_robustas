using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Enums;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)                
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve conter ao menos 6 caracteres.");
        }

        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public string Senha { get; set; }
        public EnumStatusJogador Status { get; set; }
    }
}
