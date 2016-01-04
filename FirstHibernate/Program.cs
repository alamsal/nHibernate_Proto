using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using FirstHibernate.Items;

namespace FirstHibernate
{
    class Program
    {
        static void Main(string[] args)
        {

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


            //cfg.AddAssembly(typeof(PopEvalAttribute).Assembly);
            cfg.AddAssembly(typeof(PopEval).Assembly);

           
             
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
           

            try
            {
                
                
                ICriteria criteria = session.CreateCriteria(typeof(PopEvalAttribute));
                IList<PopEvalAttribute> fiaPlots = criteria.List<PopEvalAttribute>();
                int count = fiaPlots.Count;
                
                
                ICriteria criteria1 = session.CreateCriteria(typeof(PopEval));
                IList<PopEval> eval = criteria1.List<PopEval>();
                int count2 = eval.Count;
                
                 
                IQuery query = session.CreateQuery("select p from PopEval p");
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }


            Console.ReadLine();
        }
    }
}
