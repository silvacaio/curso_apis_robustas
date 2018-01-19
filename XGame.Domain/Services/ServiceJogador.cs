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

            var id = _repositoryJogador.AdicionarJogador(jogador);
            return new AdicionarJogadorResponse() { Id = new System.Guid(), Menssage = "Operação realizada com sucesso." };
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
                AddNotification("request", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRequest"));
            //if (request == null)
            //    throw new System.Exception("Falha ao autenticar jogador: request obrigatoria.");

            //if (string.IsNullOrWhiteSpace(request.Email))
            //    throw new System.Exception("Informe uma email.");

            //if (string.IsNullOrWhiteSpace(request.Senha))
            //    throw new System.Exception("Informe uma senha.");

            //if (request.Senha.Length < 6)
            //    throw new System.Exception("A senha deve ter ao menos 6 caracteres.");

            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);
            AddNotifications(jogador, email);

            if (this.IsInvalid())
                return null;

            var response = _repositoryJogador.AutenticarJogador(jogador.Email.Endereco, jogador.Senha);
            return response;
        }
    }
}
