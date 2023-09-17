using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MystatService
{
    public static class HelperConfig
    {
        public static string ConnectionString { get;} = @"Server=(localdb)\MSSQLLocalDB;Database=MyStatProject;Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=True";
    }
}
