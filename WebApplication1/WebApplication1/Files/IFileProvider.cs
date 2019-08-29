using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.DAL;

namespace WebApplication1.Files
{
    public interface IFileProvider
    {
        string Name { get; }

        void Save(BinaryFile file, Stream content);

        Stream Load(BinaryFile file);
    }
}