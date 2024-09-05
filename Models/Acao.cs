using SistemaProjetos1._3.Models;
using SitemaProjetos1._3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaProjetos1._3.Models
{
    public class Acao
    {
        [Key]
        public int IdAcao { get; set; }

        [Required]
        public int IdProjeto { get; set; }
        public Projeto Projeto { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeAcao { get; set; }

        [MaxLength(500)]
        public string DescricaoAcao { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
