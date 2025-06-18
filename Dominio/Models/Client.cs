using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Models
{
    [Table("CLIENTS")] 
    public class Client
    {
        [Key]
        [Column("SCLIENT", TypeName = "char(14)")]
        [StringLength(14)]
        public string Sclient { get; set; } = null!;

        [Column("DBIRTHDAT")]
        public DateTime? Dbirthdat { get; set; }

        [Column("SFIRSTNAME", TypeName = "char(20)")]
        [StringLength(20)]
        public string? Sfirstname { get; set; }

        [Column("SLASTNAME", TypeName = "char(20)")]
        [StringLength(20)]
        public string? Slastname { get; set; }

        [Column("SLASTNAME2", TypeName = "char(20)")]
        [StringLength(20)]
        public string? Slastname2 { get; set; }

        [Column("SCUIT", TypeName = "char(14)")]
        [StringLength(14)]
        public string? Scuit { get; set; }

        [Column("SLEGALNAME", TypeName = "char(20)")]
        [StringLength(20)]
        public string? Slegalname { get; set; }

        [Column("SCLIENAME", TypeName = "char(64)")]
        [StringLength(64)]
        public string? Scliename { get; set; }

        [Column("SSEXCLIEN", TypeName = "char(1)")]
        [StringLength(1)]
        [ForeignKey(nameof(Sex))]
        public string? Ssexclien { get; set; }

        [Column("NNATIONALITY")]
        [ForeignKey(nameof(Nacionality))]
        public int? Nnationality { get; set; }

        [Column("NSTATREGT")]
        public int Nstatregt { get; set; }

        [Column("DCOMPDATE")]
        public DateTime Dcompdate { get; set; }

        [Column("NUSERCODE")]
        [ForeignKey(nameof(Usuario))]
        public int? Nusercode { get; set; }

        public virtual Users Usuario { get; set; }

        public virtual Sexo Sex { get; set; }
        public virtual Nacionalidad Nacionality {  get; set; }

    }

}