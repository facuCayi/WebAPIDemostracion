using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Models
{
    [Table("Table5518")]
    public class Nacionalidad
    {

        [Column("NNATIONALITY")]
        public int Nnationality { get; set; }

        [Column("DCOMPDATE")]
        public DateTime Dcomdate { get; set; }


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
