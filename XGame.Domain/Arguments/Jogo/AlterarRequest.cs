using System;

namespace XGame.Domain.Arguments.Jogo
{
    public class AlterarRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Genero { get; set; }
        public string Produtora { get; internal set; }
        public string Distribuidora { get; set; }
        public string Site { get; set; }
    }
}
