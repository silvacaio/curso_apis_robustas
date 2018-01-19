using System.Collections.Generic;
using System.Linq;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
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

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorResquest request)
        {
            //var email = new Email(request.Email);
            var email = new Email(request.Email);
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var jogador = new Jogador(nome, email, request.Senha);

            if (this.IsInvalid())
                return null;

            jogador = _repositoryJogador.AdicionarJogador(jogador);
            return (AdicionarJogadorResponse)jogador;
        }

        public AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request)
        {
            throw new System.NotImplementedException();
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
                AddNotification("request", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRequest"));

            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);
            AddNotifications(jogador, email);

            if (this.IsInvalid())
                return null;

            jogador = _repositoryJogador.AutenticarJogador(jogador.Email.Endereco, jogador.Senha);

            return (AutenticarJogadorResponse)jogador;
        }

        public IEnumerable<JogadorResponse> ListarJogadores()
        {
            return _repositoryJogador.ListarJogadores().Select(jogador => (JogadorResponse)jogador).ToList();
        }
    }
}
