using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using WebApplication1.DAL.Filters;


namespace WebApplication1.DAL.Repositories
{
    public class BinaryFileRepository : Repository<BinaryFile, BinaryFileFilter>
    {
        public BinaryFileRepository(ISession session) : base(session)
        {
        }
    }
}
