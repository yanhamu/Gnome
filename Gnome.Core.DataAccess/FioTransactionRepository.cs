using Gnome.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gnome.Core.DataAccess
{
    public class FioTransactionRepository
    {
        private readonly SqlConnection connection;

        public FioTransactionRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public List<FioTransaction> Retrieve(int limit)
        {
            throw new NotImplementedException();
        }
    }
}