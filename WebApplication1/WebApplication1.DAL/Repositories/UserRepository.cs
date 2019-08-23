﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;

namespace WebApplication1.DAL.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ISession session) 
            : base(session)
        {
        }

        public bool Exists(string login)
        {
            var crit = session.CreateCriteria<User>()
                .Add(Restrictions.Eq("FIO", login))
                .SetProjection(Projections.Count("Id"));
            var count = Convert.ToInt64(crit.UniqueResult());
            return count > 0;
        }
    }
}
