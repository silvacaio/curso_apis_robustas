using XGame.Infra.Persistence;

namespace XGame.Infra.Transactions
{
    public class UnityOfWork : IUnitOfWork
    {
        private readonly XGameContext _context;

        public UnityOfWork(XGameContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
