using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace WebApplication1.DAL.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ISession session) 
            : base(session)
        {
        }
    }
}
