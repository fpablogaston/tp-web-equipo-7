using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dominio
{
    public class Articulo
    {

        private int idArticulo;
        private string codigoArticulo;
        private string nombre;
        private string descripcion;
        private Marca marca;
        private Categoria categoria;

        public string ImagenUrl => Imagenes.FirstOrDefault();
        public List<string> Imagenes { get; set; } = new List<string>();
        private decimal precio;

        public int IdArticulo
        {
            get { return idArticulo; }
            set { idArticulo = value; }
        }

        [DisplayName("Código Articulo")]
        public string CodigoArticulo
        {
            get { return codigoArticulo; }
            set { codigoArticulo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [DisplayName("Descripción")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public Marca Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        [DisplayName("Categoría")]
        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
      

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

    }
}
