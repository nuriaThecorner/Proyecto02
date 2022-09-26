using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Principal.ViewModels
{
    public class HomeDiscoArtistaViewModel
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


    public class HomeDiscoArtistaViewModel2
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string decripcion { get; set; }
        public string imagen { get; set; }
        public string spotify { get; set; }
        public string twitter { get; set; }

        public virtual ICollection<Disco> Disco { get; set; }



    }
}