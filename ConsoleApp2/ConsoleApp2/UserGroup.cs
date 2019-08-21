using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class UserGroup
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<User> Users { get; set; }
    }

    public class UserGroupMap: ClassMap<UserGroup>
    {
        public UserGroupMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.Name).Length(100);
            HasMany(u => u.Users).AsList().Inverse();
        }
    } 
}
