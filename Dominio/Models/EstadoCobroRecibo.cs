using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio.Models
{
    [Table("TABLE191")]
    public class EstadoCobroRecibo
    {
        [Column("NSTATUS_PAY")]
        public int Nstatuspay { get; set; }

        [Column("SDESCRIPT", TypeName = "char(30)")]
        [StringLength(30)]
        public string Sdescript { get; set; }

        [Column("DCOMPDATE")]
        public DateTime Dcompdate { get; set; }

        [Column("NSTATREGT")]
        public int Nstatregt { get; set; }

        [Column("NUSERCODE")]
        public int? Nusercode { get; set; }
        public virtual Users Usuario { get; set; }

    }
}
