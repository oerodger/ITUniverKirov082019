using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DAL
{
    public class BinaryFileContent
    {
        public virtual long Id { get; set; }

        public virtual BinaryFile BinaryFile { get; set;}

        public virtual byte[] Content { get; set; }
    }

    public class BinaryFileContentMap: ClassMap<BinaryFileContent>
    {
        public BinaryFileContentMap()
        {
            Id(f => f.Id).GeneratedBy.HiLo("100");
            Map(f => f.Content).Length(int.MaxValue);
            References(f => f.BinaryFile).Cascade.SaveUpdate();
        }
    }
}
