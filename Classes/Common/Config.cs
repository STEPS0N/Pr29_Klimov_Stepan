using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlimovPR29.Classes.Common
{
    public class Config
    {
        public static string ConnectionConfig = "server=localhost;port=3307;uid=root;pwd=;database=pcClub;";
        public static MySqlServerVersion Version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
