﻿using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using FirstHibernate.Items;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace FirstHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            //log4net.Config.XmlConfigurator.Configure();

            const string dataSource = "(DESCRIPTION=(ADDRESS_LIST=(LOAD_BALANCE=true)(FAILOVER=true)(ADDRESS=(PROTOCOL=TCP)(HOST=scmcibizrac01.mci.fs.fed.us)(PORT = 1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=FIADBA.mci.fs.fed.us)))";
            const string username = "aashislamsal";
            const string password = "~Arabic_2022";

            var connectionString = string.Format("User Id={0};Password={1};Data Source={2}", username, password, dataSource);

            Configuration cfg = new Configuration();
            cfg.DataBaseIntegration(db =>
            {
                db.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
                db.Dialect<NHibernate.Dialect.Oracle10gDialect>();
                db.Driver<NHibernate.Driver.OracleDataClientDriver>();
                db.ConnectionString = connectionString;


                // enabled for testing
                db.LogFormattedSql = true;
                db.LogSqlInConsole = true;

            });
            

            cfg.AddAssembly(typeof(PopEvalAttribute).Assembly);
            //cfg.AddAssembly(typeof(PopEval).Assembly);

            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();

            try
            {
                /*
                
                ICriteria criteria = session.CreateCriteria(typeof(PopEvalAttribute));
                IList<PopEvalAttribute> fiaPlots = criteria.List<PopEvalAttribute>();
                int count = fiaPlots.Count;
                
                
                ICriteria criteria1 = session.CreateCriteria(typeof(PopEval));
                IList<PopEval> eval = criteria1.List<PopEval>();
                int count2 = eval.Count;
                */
                /*
                IQuery query = session.CreateQuery("from PopEval");
                query.SetFirstResult(0);
                query.SetMaxResults(5);
                //var results = query.SetResultTransformer(Transformers.AliasToBean(typeof(ColumnSubset)));
                //IList<ColumnSubset> vals = results.List<ColumnSubset>();

                IList<PopEval> results = query.List<PopEval>();

                */
                
                /*
                string hqlQuery = @"select p.Cn, p.Rscd from PopEval p where p.Cn>100";
                IQuery query = session.CreateQuery(hqlQuery);

                IList list = query.List();
                */
                var val = session.CreateCriteria<PopEval>().SetProjection(Projections.ProjectionList()
                                                                              .Add(Projections.Property("Cn"), "MyVal")
                                                                              .Add(Projections.Property("EvalDescr"), "MyVal2")).
                    SetResultTransformer(Transformers.AliasToBean<ColumnSubset>()).List<ColumnSubset>();

            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }


            Console.ReadLine();
        }
    }
}
