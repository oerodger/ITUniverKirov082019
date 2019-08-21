using Autofac;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DI
            /*var containerBuilder = new ContainerBuilder();
            containerBuilder
                .RegisterType<HttpRemoteService>()
                .As<IHttpRemoteService>()
                .SingleInstance();
            containerBuilder.RegisterType<YandexWeatherService>()
                .As<IWeatherService>()
                .AsSelf()
                .PropertiesAutowired()
                .SingleInstance();
            containerBuilder.RegisterType<GoogleWeatherService>()
                .As<IWeatherService>()
                .SingleInstance();
            var container = containerBuilder.Build();

            var remote = container.Resolve<YandexWeatherService>();
            var services = container.Resolve<IWeatherService[]>();
            foreach (var service in services)
            {
                dynamic res = service.Get("Kirov");
                Console.WriteLine($"{res.url}");
            } */

            #endregion

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(x => { 
                var cfg = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString("Data Source=N0209\\SQLSERVER2017;Initial Catalog=ITUniver;Integrated Security=SSPI;")
                        .Dialect<MsSql2012Dialect>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>());
                    var conf = cfg.BuildConfiguration();
                    var schemeExport = new SchemaUpdate(conf);
                    schemeExport.Execute(true, true);
                return cfg.BuildSessionFactory();
            }).As<ISessionFactory>().SingleInstance();
            containerBuilder.Register(x => x.Resolve<ISessionFactory>().OpenSession())
                .As<ISession>();
            var container = containerBuilder.Build();
            
            var user = new User { FIO = "Иванов Иван Иванович" };
            var session = container.Resolve<ISession>();
            using (var tran = session.BeginTransaction())
            {
                try
                {
                    session.Save(user);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                } 
            }
        }


    }
}
