using Autofac;
using System;
using System.Data.SqlClient;

namespace Gnome.Tests.Common
{
    public class BaseDbTest : IDisposable
    {
        protected IContainer container;

        public BaseDbTest()
        {
            container = DiInitializer.BuildContainer();
        }

        public void Dispose()
        {
            var sqlConnection = container.Resolve<SqlConnection>();
            // TODO fix
            //sqlConnection.Execute(Database.Clear_All);
            container.Dispose();
        }
    }
}
