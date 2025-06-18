using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.Models
{
    [Table("PRODUCTMASTER")]
    public class Productmaster
    {
        [Column("NBRANCH")]
        [ForeignKey(nameof(Branch))]
        public int Nbranch { get; set; }

        [Column("NPRODUCT")]
        public int Nproduct { get; set; }

        [Column("SDESCRIPT", TypeName = "char(30)")]
        [StringLength(30)]
        public string? Sdescript { get; set; } = string.Empty;

        [Column("SSHORT_DES", TypeName = "char(12)")]
        [StringLength(12)]
        public string? Sshort_des { get; set; }

        [Column("DCOMPDATE")]
        public DateTime Dcompdate { get; set; }

        [Column("NSTATREGT")]
        public int Nstatregt { get; set; }

        [Column("NUSERCODE")]
        [ForeignKey(nameof(Usuario))]
        public int? Nusercode { get; set; }

        public virtual RamoComercial Branch { get; set; }

        public virtual Users Usuario { get; set; }
    }
}
