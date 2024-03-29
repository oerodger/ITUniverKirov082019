﻿using FluentNHibernate.Mapping;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DAL.Filters;


namespace WebApplication1.DAL
{
    [Filter(Type = typeof(UserFilter))]
    public class User: IUser<long>
    {
        public virtual long Id { get; set; }

        [FastSearch]
        public virtual string UserName { get; set; }

        [FastSearch]
        public virtual string FIO { get; set; }

        public virtual string Password { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual User CreationAuthor { get; set; }

        [FastSearch]
        public virtual string Email { get; set; }

        [FastSearch(FiledType = FiledType.Int)]
        public virtual int Age { get; set; }

        public virtual DateTime BirthDate { get; set; }

        public virtual BinaryFile AvatarFile { get; set; }
        
    }

    public class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("100");
            Map(u => u.FIO).Length(100);   
            Map(u => u.Password).Length(500);
            Map(u => u.UserName).Length(30);
            Map(u => u.CreationDate);
            Map(u => u.BirthDate);
            Map(u => u.Age);
            Map(u => u.Email);
            References(u => u.AvatarFile).Cascade.SaveUpdate();
            References(u => u.CreationAuthor).Cascade.SaveUpdate();
        }
    }
}
