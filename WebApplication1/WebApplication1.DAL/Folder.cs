using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DAL
{
    public class Folder
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Folder Parent { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual User CreationAuthor { get; set; }

    }

    public class FolderMap : ClassMap<Folder>
    {
        public FolderMap()
        {
            Id(f => f.Id).GeneratedBy.HiLo("100");
            Map(f => f.Name).Length(100);
            References(f => f.Parent).Cascade.SaveUpdate();
            Map(f => f.CreationDate);
            References(f => f.CreationAuthor);
        }
    }
}
