﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DAL.Filters
{
    public class FolderFilter: BaseFilter
    {
        public Folder Parent { get; set; }
    }
}
