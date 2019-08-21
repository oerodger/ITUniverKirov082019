using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Profile
    {
        public virtual long Id { get; set; }

        public virtual DateTime LastAuth { get; set; }
    }

    public class ProfileMap : ClassMap<Profile>
    {
        public ProfileMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u=> u.LastAuth);
        }
    } 
}
