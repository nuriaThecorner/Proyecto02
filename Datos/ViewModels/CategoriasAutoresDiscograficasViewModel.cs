using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels
{
    public class CategoriasAutoresDiscograficasViewModel
    {

        public virtual IList<Autor> autor { get; set; }
        public virtual IList<Categoria> categoria { get; set; }
        public virtual IList<Discografica> discografica { get; set; }
        public virtual Disco disco { get; set; }


    }
}
