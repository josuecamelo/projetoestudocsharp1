using System;
using System.ComponentModel.DataAnnotations;

namespace WebEscola.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }

        [Display(Name = "Primeiro Nome")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve ter de 3 a 40 caracteres")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [StringLength(40)]
        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        public string Sobrenome { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime Data { get; set; }
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O estado deve ter 2 caracteres")]
        [Required(ErrorMessage = "O estado é obrigatório")]
        public string Estado { get; set; }
    }
}
