using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entidades
{
    [Table("Livros")]
    public class Livros
    {
        [Display(Description ="Código")]     
        public int Id { get; set; }

        [Display(Description = "Nome")]  
        public string Nome { get; set; }

        [Display(Description = "Preco")]
        public decimal Preco { get; set; }

        [Display(Description = "Tipo")]
        public int Tipo { get; set; }

        [Display(Description = "Autor")]
        public string Autor { get; set; }
    }
}
