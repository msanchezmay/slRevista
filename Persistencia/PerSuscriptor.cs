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
    public class PerSuscriptor : Base
    {
        public PerSuscriptor(string conexion) : base(conexion) { }

        public int Eliminar(int Dato)
        {
            List<DbParameter> parameterList = new List<DbParameter>();
            parameterList.Add(gestion.GetParameter("@IdSuscriptor", Dato));
            return gestion.ExecuteNonQuery("ZD_Suscriptor", parameterList, CommandType.StoredProcedure);
        }
        public int Insertar(EntSuscriptor objeto)
        {
            List<DbParameter> parameterList = new List<DbParameter>();
            parameterList.Add(gestion.GetParameterOut("@IdSuscriptor", SqlDbType.Int, objeto.Idsuscriptor, ParameterDirection.InputOutput));
            parameterList.Add(gestion.GetParameter("@Nombre", objeto.Nombre));
            parameterList.Add(gestion.GetParameter("@Apellido", objeto.Apellido));
            parameterList.Add(gestion.GetParameter("@Numerodocumento", objeto.Numerodocumento));
            parameterList.Add(gestion.GetParameter("@Direccion", objeto.Direccion));
            parameterList.Add(gestion.GetParameter("@Tipodocumento", objeto.Tipodocumento));           
            parameterList.Add(gestion.GetParameter("@Telefono", objeto.Telefono));
            parameterList.Add(gestion.GetParameter("@Email", objeto.Email));
            parameterList.Add(gestion.GetParameter("@Nombreusuario", objeto.Nombreusuario));
            parameterList.Add(gestion.GetParameter("@Password", objeto.Password));
            gestion.ExecuteNonQuery("ZIU_Suscriptor", parameterList, CommandType.StoredProcedure);
            return gestion.GetValueReturn<int>("@IdSuscriptor");
        }

        public List<EntSuscriptor> ObtenerListado(params object[] parametros)
        {
            List<EntSuscriptor> lista = new List<EntSuscriptor>();
            EntSuscriptor objeto = null;

            List<DbParameter> parameterList = new List<DbParameter>();
            parameterList.Add(gestion.GetParameter("@IdSuscriptor", parametros[0]));
            parameterList.Add(gestion.GetParameter("@NumeroDocumento", parametros[1]));
            parameterList.Add(gestion.GetParameter("@TipoDocumento", parametros[2]));
            using (DbDataReader dataReader = gestion.GetDataReader("ZC_Suscriptor", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        objeto = new EntSuscriptor();
                        objeto.Idsuscriptor = General.obtenerValor<long>(dataReader["IdSuscriptor"]);
                        objeto.Nombre = General.obtenerValor<string>(dataReader["Nombre"]);
                        objeto.Apellido = General.obtenerValor<string>(dataReader["Apellido"]);
                        objeto.Numerodocumento = General.obtenerValor<long>(dataReader["NumeroDocumento"]);
                        objeto.Direccion = General.obtenerValor<string>(dataReader["Direccion"]);
                        objeto.Tipodocumento = General.obtenerValor<string>(dataReader["TipoDocumento"]);
                        objeto.Telefono = General.obtenerValor<string>(dataReader["Telefono"]);
                        objeto.Email = General.obtenerValor<string>(dataReader["Email"]);
                        objeto.Nombreusuario = General.obtenerValor<string>(dataReader["NombreUsuario"]);
                        objeto.Password = General.obtenerValor<string>(dataReader["Password"]);
                        objeto.Dias = General.obtenerValor<long>(dataReader["dias"]);
                        lista.Add(objeto);
                    }
                }
            }
            return lista;
        }

        public long BuscarUsuario(params object[] parametros)
        {
            long Existe = 0;
            List<DbParameter> parameterList = new List<DbParameter>();
            parameterList.Add(gestion.GetParameter("@NombreUsuario", parametros[0]));
   
            using (DbDataReader dataReader = gestion.GetDataReader("ZC_Suscriptor_buscar_usuario", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    if (dataReader.Read())
                    {
                        
                        Existe = General.obtenerValor<long>(dataReader["Existe"]); 
                    }
                }
            }
            return Existe;
        }

    }
}
