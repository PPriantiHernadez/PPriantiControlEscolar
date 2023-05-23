using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConection()
        {
             return "Data Source=.;Initial Catalog=PPriantiControlEscolar;Persist Security Info=True;User ID=sa;Password=pass@word1";
            //return ConfigurationManager.ConnectionStrings["PPriantiControlEscolar"].ToString();
        }
    }
}
