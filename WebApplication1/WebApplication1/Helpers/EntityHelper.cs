using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.DAL.Filters;
using WebApplication1.DAL.Repositories;

namespace WebApplication1
{
    public static class EntityHelper
    {
        public static IRepository GetRepository(Type type)
        {
            var filterType = type.GetCustomAttribute<DAL.Filters.FilterAttribute>();
            var repType = typeof(Repository<,>).MakeGenericType(type, filterType.Type);
            return (IRepository)DependencyResolver.Current.GetService(repType);
        }
    }
}
