//using XGame.Infra.Persistence;

//namespace XGame.Infra.Transactions
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        private readonly XGameContext _context;

//        public UnitOfWork(XGameContext context)
//        {
//            _context = context;
//        }

//        public void Commit()
//        {
//            var teste = _context.ChangeTracker.HasChanges();
//            _context.SaveChanges();
//        }
//    }
//}

using XGame.Infra.Persistence;

namespace XGame.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly XGameContext _context;

        public UnitOfWork(XGameContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
