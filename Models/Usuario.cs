using SitemaProjetos1._3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaProjetos1._3.Models
{
    public enum FuncaoUsuario
    {
        Designer,
        Gerente_Tecnico,
        Desenvolvedor_FrontEnd,
        Desenvolvedor_BackEnd,
        Desenvolvedor_Fullstack,
        Designer_IU,
        Designer_ExperienciaDoUsuario
    }
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeUsuario { get; set; }

        public string FotoMimeType { get; set; }
        public byte[] Foto { get; set; }
        [NotMapped]
        public IFormFile formFile { get; set; }

        [Required]
        public FuncaoUsuario Funcao { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }
        public virtual ICollection<Acao> Acoes { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
