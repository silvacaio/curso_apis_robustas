using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Enums;
using XGame.Domain.Extensions;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador(Nome nome, Email email, string senha) : this(email, senha)
        {
            AddNotifications(nome);
        }

        public Jogador(Email email, string senha)
        {
            Email = email;
            Id = new Guid();
            Status = EnumStatusJogador.EmAnalise;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve conter ao menos 6 caracteres.");

            if (IsValid())
                Senha = senha.ConvertToMD5();

            AddNotifications(Email);
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

        public Guid Id { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public EnumStatusJogador Status { get; private set; }
    }
}
