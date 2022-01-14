using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AnimalHealthCareWS.utils
{
    class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory _sessionFactory;
        static NHibernateHelper()
        {
            _sessionFactory = FluentConfigure();
        }
        public static ISession GetCurrentSession()
        {
            return _sessionFactory.OpenSession();
        }
        public static void CloseSession()
        {
            _sessionFactory.Close();
        }
        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }

        public static ISessionFactory FluentConfigure()
        {

            try
            {
                return Fluently.Configure()
                    //which database
                    .Database(
                        MySQLConfiguration.Standard
                            .ConnectionString(@"Server=localhost;Port=3306;Database=animalhealthcare;Uid=root;Pwd=;")
                            )
                    //2nd level cache
                    .Cache(
                        c => c.UseQueryCache()
                            .UseSecondLevelCache()
                            .ProviderClass<NHibernate.Cache.HashtableCacheProvider>())
                    //find/set the mappings
                    //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMapping>())
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .BuildSessionFactory();
            } catch(Exception e )
            {
                Console.WriteLine(e);
                throw e;
            }
            }
    }
   
}