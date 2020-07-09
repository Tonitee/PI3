using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AtividadeAula10.Models;

namespace AtividadeAula10.Data
{
    public class AtividadeAula10Context : DbContext
    {
        public AtividadeAula10Context (DbContextOptions<AtividadeAula10Context> options)
            : base(options)
        {
        }

        public DbSet<AtividadeAula10.Models.Produto> Produto { get; set; }

        public DbSet<AtividadeAula10.Models.Categoria> Plataforma { get; set; }

    }
}
