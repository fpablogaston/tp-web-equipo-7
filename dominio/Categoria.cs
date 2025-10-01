using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {
        private int idCategoria;
        private string descripcion;
        public int IdCategoria
        { 
            get { return idCategoria; } 
            set { idCategoria = value; }
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
