using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class CtrlRevista
    {
        #region Propiedades
        private PerSuscriptor opSql = new PerSuscriptor(new PerConexion().SConn);
        private PerSuscripcion opSqlSuscripcion = new PerSuscripcion(new PerConexion().SConn);
        #endregion

        #region Operaciones Suscriptor
        public long BuscarUsuario(string objeto)
        {            
            return opSql.BuscarUsuario(objeto);
        }
        public EntSuscriptor AltaSuscriptor(EntSuscriptor objeto)
        {
           int id= opSql.Insertar(objeto);
            objeto.Idsuscriptor = id;
            return objeto;
        }

        public void EliminarSuscriptor(int id)
        {
            opSql.Eliminar(id);                       
        }

        public List<EntSuscriptor> ObtenerSuscriptor(EntSuscriptor objeto)
        {
            var detalle= opSql.ObtenerListado(objeto.Idsuscriptor, objeto.Numerodocumento, objeto.Tipodocumento);
            return detalle;
        }
        #endregion

        #region Operaciones Suscripcion
        public EntSuscripcion AltaSuscripcion(EntSuscripcion objeto)
        {
            int id = opSqlSuscripcion.Insertar(objeto);
            objeto.Idsuscriptor = id;
            return objeto;
        }

        public void EliminarSuscripcion(int id)
        {
            opSqlSuscripcion.Eliminar(id);
        }

        public List<EntSuscripcion> ObtenerSuscripcion(EntSuscripcion objeto)
        {
            var detalle = opSqlSuscripcion.obtenerSuscripcion(objeto.Idasociacion, objeto.Idsuscriptor);
            return detalle;
        }
        #endregion
    }
}
