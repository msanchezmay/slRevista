using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbLibreria
{
    public static class General
    {
        #region Metodos tratamiento datos

        public static T st_obtenerValor<T>(object Valor)
        {
            if (Valor == null || Valor.Equals(DBNull.Value))
                return default(T);
            else
            {
                if (typeof(T).IsGenericType)
                {
                    try
                    {
                        T res = Activator.CreateInstance<T>();

                        if (typeof(T).Name.ToUpper().Contains("NULLAB"))
                        {
                            res = (T)Convert.ChangeType(Valor, typeof(T).GetGenericArguments()[0]);
                        }
                        else
                        {
                            PropertyInfo prop = typeof(T).GetProperty("Value");
                            prop.SetValue(res, Convert.ChangeType(Valor, typeof(T).GetGenericArguments()[0]), null);
                        }
                        return res;
                    }
                    catch
                    {
                        return default(T);
                    }
                }
                else
                    return (T)Convert.ChangeType(Valor, typeof(T));
            }
        }

        public static bool EsNulo(object Valor)
        {
            if (Valor == null || Valor.Equals(DBNull.Value))
                return true;
            else
                return false;
        }

        public static object obtenerValorObj<T>(object Valor)
        {
            if (Valor == null || Valor.Equals(DBNull.Value))
                return default(T);
            else
            {
                if (typeof(T).IsGenericType)
                {
                    try
                    {
                        return Convert.ChangeType(Valor, typeof(T).GetGenericArguments()[0]);
                    }
                    catch
                    {
                        return default(T);
                    }
                }
                else
                    return (T)Convert.ChangeType(Valor, typeof(T));
            }
        }

        public static T obtenerValor<T>(object Valor)
        {
            if (Valor == null || Valor.Equals(DBNull.Value))
                return default(T);
            else
            {
                if (typeof(T).IsGenericType)
                {
                    try
                    {
                        T res = Activator.CreateInstance<T>();

                        if (typeof(T).Name.ToUpper().Contains("NULLAB"))
                        {
                            res = (T)Convert.ChangeType(Valor, typeof(T).GetGenericArguments()[0]);
                        }
                        else
                        {
                            PropertyInfo prop = typeof(T).GetProperty("Value");
                            prop.SetValue(res, Convert.ChangeType(Valor, typeof(T).GetGenericArguments()[0]), null);
                        }
                        return res;
                    }
                    catch
                    {
                        return default(T);
                    }
                }
                else
                    return (T)Convert.ChangeType(Valor, typeof(T));
            }
        }

        #endregion Metodos tratamiento datos

        public static DateTime? GetValorParametroFecha(int indice, object def, object[] parametros)
        {
            try
            {
                if (indice <= parametros.Length)
                {
                    return (DateTime)parametros[indice - 1];
                }
                else
                    return null;
            }
            catch { return null; }
        }

        public static object GetValorParametro(int indice, object def, object[] parametros)
        {
            try
            {
                if (indice <= parametros.Length)
                {
                    return parametros[indice - 1];
                }
                else
                    return def;
            }
            catch { return def; }
        }

        public static T GetValorParametro<T>(int indice, object[] parametros)
        {
            try
            {
                if (indice <= parametros.Length)
                {
                    return (T)parametros[indice - 1];
                }
                else
                    return default(T);
            }
            catch { return default(T); }
        }
    }
}