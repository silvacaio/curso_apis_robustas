using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;

namespace XGame.Domain.Services
{
    public class ServiceJogo : Notifiable, IServiceJogo
    {
        private readonly IRepositoryJogo _repositoryJogo;

        public ServiceJogo(IRepositoryJogo repositoyJogo)
        {
            _repositoryJogo = repositoyJogo;
        }

        public AdicionarResponse Adicionar(AdicionarRequest request)
        {
            var jogo = new Jogo(request.Nome, request.Descricao, request.Produtora,
                request.Distribuidora, request.Genero, request.Site);

            AddNotifications(jogo);

            if (IsInvalid())
                return null;

            jogo = _repositoryJogo.Adicionar(jogo);
            return (AdicionarResponse)jogo;
        }

        public AlterarResponse Alterar(AlterarRequest request)
        {
            var jogo = _repositoryJogo.ObterPorId(request.Id);

            if (jogo == null)
            {
                AddNotification("Id", "Jogo não encontrado");
                return null;
            }

            jogo.Alterar(request.Nome, request.Descricao, request.Produtora, request.Distribuidora,
                request.Genero, request.Site);

            AddNotifications(jogo);
            if (IsInvalid())
                return null;

            _repositoryJogo.Editar(jogo);

            return (AlterarResponse)jogo;
        }

        public IEnumerable<JogoResponse> Listar()
        {
            throw new NotImplementedException();
        }

        public ResponseBase Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
