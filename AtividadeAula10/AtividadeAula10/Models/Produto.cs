using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadeAula10.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} deve ter de {2} a {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DisplayFormat(DataFormatString ="R${0:F2}")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public Categoria Plataforma { get; set; }

        public int PlataformaId { get; set; }

        public Produto()
        {
        }

        public Produto(int id, string nome, double preco, Categoria plataforma)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Plataforma = plataforma;
        }
    }
}
