using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadeAula10.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} deve ter de {2} a {1} caracteres")]
        public string Nome { get; set; }
        public ICollection<Produto> Plataformas { get; set; }

        public Categoria()
        {
        }

        public Categoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdicionarPlataforma(Produto produto)
        {
            Plataformas.Add(produto);
        }

        public void RemoverPlataforma(Produto produto)
        {
            Plataformas.Remove(produto);
        }
    }
}
