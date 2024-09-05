using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using SistemaProjetos1._3.Models;

namespace SitemaProjetos1._3.Models
{
    public enum StatusProjeto
    {
        Aprovado,
        EmAndamento,
        Cancelado,
        EmAnalise
    }

    [Flags]
    public enum LocalProjeto
    {
        Nenhum = 0,
        CETAF_Aju = 1,
        CEFEM = 2,
        CETCC = 4,
        CETAF_Est = 8,
        Outro = 16
    }
    public class Projeto
    {
        [Key]
        public int IdProjeto { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeProjeto { get; set; }

        [Required]
        public StatusProjeto StatusPro { get; set; }

        [MaxLength(500)]
        public string DescricaoProjeto { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public LocalProjeto LocalPro { get; set; }

        [Required]
        public int CargaHoraria { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorEmReais { get; set; }
        public string FotoMimeType { get; set; }
        public byte[] Foto { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }

        public virtual ICollection<Acao> Acoes { get; set; }
    }
}
