using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;

namespace XGame.Domain.Services
{
    public class ServiceJogador : IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador(IRepositoryJogador repositoyJogador)
        {
            _repositoryJogador = repositoyJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorResquest request)
        {
            var id = _repositoryJogador.AdicionarJogador(request);
            return new AdicionarJogadorResponse() { Id = id, Menssage = "Operação realizada com sucesso." };
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
                throw new System.Exception("Falha ao autenticar jogador: request obrigatoria.");

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new System.Exception("Informe uma email.");

            if (string.IsNullOrWhiteSpace(request.Senha))
                throw new System.Exception("Informe uma senha.");

            if (request.Senha.Length < 6)
                throw new System.Exception("A senha deve ter ao menos 6 caracteres.");

            var response = _repositoryJogador.AutenticarJogador(request);
            return response;
        }
    }
}
