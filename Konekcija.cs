using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace projekat_2026_Andjela_Stoisavljevic
{
    public class Konekcija
    {
        static public SqlConnection connect()
        {
            string CS = ConfigurationManager.ConnectionStrings["skola"];
            return null;
        }
    }
}
