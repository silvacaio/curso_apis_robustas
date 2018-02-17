using System;
using System.Collections.Generic;
using System.Linq;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador(IRepositoryJogador repositoyJogador)
        {
            _repositoryJogador = repositoyJogador;
        }

        public AdicionarJogadorResponse Adicionar(AdicionarJogadorResquest request)
        {
            var email = new Email(request.Email);
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var jogador = new Jogador(nome, email, request.Senha);

            AddNotifications(email, nome, jogador);

            //new AddNotifications<ServiceJogador>(this)
            //    .IfTrue(, "Já existe este e-mail cadastrado");

            if (_repositoryJogador.Existe(x => x.Email.Endereco == request.Email))
            {
                AddNotification("E-mail", "Já existe este e-mail");

            }

            if (this.IsInvalid())
                return null;

            jogador = _repositoryJogador.Adicionar(jogador);
            return (AdicionarJogadorResponse)jogador;
        }

        public AlterarJogadorResponse Alterar(AlterarJogadorRequest request)
        {
            var jogador = _repositoryJogador.ObterPorId(request.Id);

            if (jogador == null)
            {
                AddNotification("Id", "Jogador não encontrado");
                return null;
            }

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);
            jogador.Alterar(nome, email);

            AddNotifications(jogador);
            if (IsInvalid())
                return null;

            _repositoryJogador.Editar(jogador);

            return (AlterarJogadorResponse)jogador;
        }

        public AutenticarJogadorResponse Autenticar(AutenticarJogadorRequest request)
        {
            if (request == null)
                AddNotification("request", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRequest"));

            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);
            AddNotifications(jogador, email);

            if (this.IsInvalid())
                return null;

            jogador = _repositoryJogador.ObterPor(x => x.Email.Endereco == jogador.Email.Endereco, x => x.Senha == jogador.Senha);

            return (AutenticarJogadorResponse)jogador;
        }

        public IEnumerable<JogadorResponse> Listar()
        {
            return _repositoryJogador.Listar().ToList().Select(jogador => (JogadorResponse)jogador);
        }

        public ResponseBase Remover(Guid id)
        {
            Jogador jogador = _repositoryJogador.ObterPorId(id);

            if (jogador == null)
            {
                AddNotification("Id", "Jogador não encontrado");
                return null;
            }

            _repositoryJogador.Remover(jogador);
            return new ResponseBase() { Message = "Removido com sucesso" };
        }
    }
}
