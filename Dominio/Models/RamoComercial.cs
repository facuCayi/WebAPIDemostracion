using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.Models
{
    [Table("TABLE10")]
    public class RamoComercial
    {
        [Column("NBRANCH")]
        public int Nbranch { get; set; }

        [Column("DCOMPDATE")]
        public DateTime Dcompdate { get; set; }


        [Column("SDESCRIPT", TypeName = "char(30)")]
        [StringLength(30)]
        public string? Sdescript { get; set; } = string.Empty;

        [Column("SSHORT_DES", TypeName = "char(12)")]
        [StringLength(12)]
        public string? Sshort_des { get; set; }

        [Column("NSTATREGT")]
        public int Nstatregt { get; set; }

        [Column("NUSERCODE")]
        public int? Nusercode { get; set; }
    }
}
