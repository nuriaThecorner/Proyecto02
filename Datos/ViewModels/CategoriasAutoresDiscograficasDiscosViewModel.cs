using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels
{
    public class CategoriasAutoresDiscograficasDiscosViewModel
    {

        public IList<Autor> autores { get; set; }

        public IList<Discografica> discograficas { get; set; }

        public IList<Categoria> categorias { get; set; }


        public Disco discos { get; set; }

    }
}
