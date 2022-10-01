using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Base
    {
        protected DbLibreria.Gestion gestion;

        public Base(string conexionString) => gestion = new DbLibreria.Gestion(conexionString);
        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString() => base.ToString();
    }
}
