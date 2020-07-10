using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Infra.Persistence;

namespace XGame.Infra.Transaction
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
