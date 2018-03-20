using System;
using System.Data.Entity;
using System.Diagnostics;
using DataFramework.Entities;

namespace DataFramework
{
    public class EF6DBContext: DbContext
    {
        [Conditional("DEBUG")]
        private static void EnableTraceIfDebug(EF6DBContext db)
        {
            db.Database.Log = s => Debug.WriteLine(s);
        }

        public DbSet<Widget> Widgets { get; set; }

        public EF6DBContext() : base("EF6DBContext")
        {
            FixEntityFrameworkDllNotDeploying();
            EnableTraceIfDebug(this);
        }
        public EF6DBContext(string connectionString) : base(connectionString)
        {
            FixEntityFrameworkDllNotDeploying();
        }

        /*
         * DO NOT REMOVE! Work around known defect in entity framework described here: 
         * https://social.msdn.microsoft.com/Forums/en-US/b348a0c2-94d9-4db5-a041-b81a97e76b3f/entityframeworksqlserver-not-deploying?forum=adodotnetentityframework 
         */
        private void FixEntityFrameworkDllNotDeploying()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
            {
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
            }
        }
    }
}
