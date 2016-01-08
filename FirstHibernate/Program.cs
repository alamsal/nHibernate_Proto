using System;
using System.Collections;
using FirstHibernate.AccessItems;
using NHibernate;
using NHibernate.Cfg;
using FirstHibernate.Items;
using NHibernate.JetDriver;

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
                
                /*
                var val = session.CreateCriteria<PopEval>().SetProjection(Projections.ProjectionList()
                                                                              .Add(Projections.Property("Cn"), "MyVal")
                                                                              .Add(Projections.Property("EvalDescr"), "MyVal2")).
                    SetResultTransformer(Transformers.AliasToBean<ColumnSubset>()).List<ColumnSubset>();

                */

                AccessDatabaseConnection();

            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }


            Console.ReadLine();
        }


        public static void AccessDatabaseConnection()
        {
            string accessDb = @"D:\Ashis_Work\FIA2FVS\TestHibernate\MyAccessTestData.accdb";
            string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}",accessDb);
            Configuration cfg = new Configuration();
            cfg.DataBaseIntegration(db1 =>
                                        {
                                            db1.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
                                            db1.Dialect<JetDialect>();
                                            db1.Driver<JetDriver>();
                                            db1.ConnectionString = connectionString;

                                            // enabled for testing
                                            db1.LogFormattedSql = true;
                                            db1.LogSqlInConsole = true;
                                        });
            cfg.AddAssembly(typeof (StandInit).Assembly);
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();

            string hqlQuery = @"select p.StandCn, p.StandId from StandInit p";
            IQuery query = session.CreateQuery(hqlQuery);

            IList list = query.List();

            int myval = list.Count;

        }

    }
}
