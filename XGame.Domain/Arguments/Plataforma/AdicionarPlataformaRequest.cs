using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Plataforma
{
    public class AdicionarPlataformaRequest : IRequest
    {
        public string Nome { get; set; }
    }
}
