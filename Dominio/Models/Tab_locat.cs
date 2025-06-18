using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Models
{
    [Table("TAB_LOCAT")]
    public class Tab_locat
    {
        [Column("NLOCAL")]
        public int Nlocal { get; set; }

        [Column("SDESCRIPT", TypeName = "char(30)")]
        [StringLength(30)]
        public string? Sdescript { get; set; }

        [Column("NMUNICIPALITY")]
        public int Nmunicipality { get; set; }

        [Column("DCOMPDATE")]
        public DateTime Dcompdate { get; set; }

        [Column("NUSERCODE")]
        public int? Nusercode { get; set; }
    }
}
