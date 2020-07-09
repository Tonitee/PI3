using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadeAula10.Models.ViewModels
{
    public class JogoViewModel
    {
        public Produto Produto { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
    }
}
