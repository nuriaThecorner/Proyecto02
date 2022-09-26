using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Principal.ViewModels
{
    public class DiscoTemaViewModel
    {

        public int id { get; set; }
        public Nullable<int> id_discografia { get; set; }
        public Nullable<int> id_autor { get; set; }
        public int id_categoria { get; set; }
        public string nombre { get; set; }
        public string imagen { get; set; }

        public virtual Autor Autor { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Discografica Discografica { get; set; }
        public virtual ICollection<Tema> Tema { get; set; }
    }
}