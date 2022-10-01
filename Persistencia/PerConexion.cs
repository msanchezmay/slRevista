using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class PerConexion
    {
        private string x;

        /// <summary>
        /// Conexion de la base de datos por medio del Web.config
        /// </summary>
        public string SConn
        {
            get { x = ConfigurationManager.AppSettings["Conexion"]; return x; }
            set { x = value; }
        }
    }
}
