using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Infra.Persistence.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador : RepositoryBase<Jogador, Guid>, IRepositoryJogador
    {
        private readonly XGameContext _context;

        public RepositoryJogador(XGameContext context) : base(context)
        {
            _context = context;
        }        
    }
}
