using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        private int IDMarca;
        private string descripcion;

        public int IdMarca 
        { 
            get { return IDMarca; } 
            set { IDMarca = value; }
        }

        public string Descripcion 
        { 
            get { return descripcion; } 
            set { descripcion = value; }
        }

        public override string ToString()
        {
            return descripcion;
        }
    }
}
