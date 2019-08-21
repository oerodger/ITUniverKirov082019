using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Role: UserGroup
    {
        public virtual string RoleName { get; set; }
    }

    public class RoleMap: SubclassMap<Role>
    {
        public RoleMap()
        {
            Map(u => u.RoleName).Length(100);
        } 
    }
}
