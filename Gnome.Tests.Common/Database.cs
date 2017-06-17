namespace Gnome.Tests.Common
{
    public class Database
    {
        public const string ConnectionString = "Data Source=TOM-LENOVO\\SQLEXPRESS;Initial Catalog=gnome-test;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public const string Clear_All = "delete from account; delete from [user]";
    }
}
