using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Entities.Base;
using XGame.Domain.Enums;
using XGame.Domain.Extensions;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : EntityBase
    {
        protected Jogador()
        {

        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Status = EnumStatusJogador.EmAnalise;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => senha, 6, 32, "A senha deve conter ao menos 6 caracteres.");

            AddNotifications(nome, email);

            if (IsValid())
                Senha = senha.ConvertToMD5();
        }

        public Jogador(Email email, string senha)
        {
            Email = email;

            new AddNotifications<Jogador>(this)
              .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve conter ao menos 6 caracteres.");

            AddNotifications(email);

            if (IsValid())
                Senha = senha.ConvertToMD5();
        }

        public void Alterar(Nome nome, Email email)
        {
            new AddNotifications<Jogador>(this)
                .IfFalse(this.Status == EnumStatusJogador.Ativo, "Só é possível alterar jogadores ativos.");
            AddNotifications(nome, email);

            if (IsInvalid()) return;

            Nome = nome;
            Email = email;

        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public EnumStatusJogador Status { get; private set; }
    }
}
