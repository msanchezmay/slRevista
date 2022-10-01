using DbLibreria;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class PerSuscripcion : Base
    {
        public PerSuscripcion(string conexion) : base(conexion) { }

        public int Eliminar(int Dato)
        {
            List<DbParameter> parameterList = new List<DbParameter>();
            parameterList.Add(gestion.GetParameter("@IdSuscriptor", Dato));
            return gestion.ExecuteNonQuery("ZD_Suscripcion", parameterList, CommandType.StoredProcedure);
        }
        public int Insertar(EntSuscripcion objeto)
        {
            List<DbParameter> parameterList = new List<DbParameter>();
            parameterList.Add(gestion.GetParameterOut("@IdAsociacion", SqlDbType.Int, objeto.Idasociacion, ParameterDirection.InputOutput));
            parameterList.Add(gestion.GetParameter("@IdSuscriptor", objeto.Idsuscriptor));
            parameterList.Add(gestion.GetParameter("@Fechaalta", objeto.Fechaalta));
            parameterList.Add(gestion.GetParameter("@Fechafin", objeto.Fechafin));
            parameterList.Add(gestion.GetParameter("@Motivofin", objeto.Motivofin));

            gestion.ExecuteNonQuery("ZIU_Suscripcion", parameterList, CommandType.StoredProcedure);
            return gestion.GetValueReturn<int>("@IdAsociacion");
        }

        public List<EntSuscripcion> obtenerSuscripcion(params object[] parametros)
        {
            List<EntSuscripcion> lista = new List<EntSuscripcion>();
            EntSuscripcion objeto = null;

            List<DbParameter> parameterList = new List<DbParameter>();
            parameterList.Add(gestion.GetParameter("@IdAsociacion", parametros[0]));
            parameterList.Add(gestion.GetParameter("@IdSuscriptor", parametros[1]));

            using (DbDataReader dataReader = gestion.GetDataReader("ZC_Suscripcion", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        objeto = new EntSuscripcion();
                        objeto.Idasociacion = General.obtenerValor<long>(dataReader["IdAsociacion"]);
                        objeto.Idsuscriptor = General.obtenerValor<long>(dataReader["IdSuscriptor"]);
                        objeto.Fechaalta = General.obtenerValor<DateTime>(dataReader["FechaAlta"]);
                        objeto.Fechafin = General.obtenerValor<DateTime>(dataReader["FechaFin"]);
                        objeto.Motivofin = General.obtenerValor<string>(dataReader["MotivoFin"]);
                        lista.Add(objeto);
                    }
                }
            }
            return lista;
        }
    }
}
