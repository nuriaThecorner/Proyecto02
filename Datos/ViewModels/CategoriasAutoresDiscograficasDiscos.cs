using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels
{
    public class CategoriasAutoresDiscograficasDiscos
    {

        public IList<Disco> discos { get; set; }

        public IList<Autor> autores { get; set; }

        public IList<Discografica> discograficas { get; set; }

        public IList<Categoria> categorias { get; set; }



        public Tema temas { get; set; }
    }
}
