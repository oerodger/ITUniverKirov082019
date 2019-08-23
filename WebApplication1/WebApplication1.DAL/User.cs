using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DAL
{
    public class User
    {
        public virtual long Id { get; set; }

        public virtual string FIO { get; set; }

        public virtual string Password { get; set; }
    }

    public class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.FIO).Length(100);   
            Map(u => u.Password).Length(500);
        }
    }
}
