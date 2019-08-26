using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using WebApplication1.DAL.Filters;

namespace WebApplication1.DAL.Repositories
{
    public class FolderRepository : Repository<Folder, FolderFilter>
    {
        public FolderRepository(ISession session) : base(session)
        {
        }

        protected override void SetupFilter(ICriteria crit, FolderFilter filter)
        {
            base.SetupFilter(crit, filter);
            if (filter.Parent != null)
            {
                crit.Add(Restrictions.Eq("Parent", filter.Parent));
            }
            else
            {
                crit.Add(Restrictions.IsNull("Parent"));
            }
        }   
    }
}
