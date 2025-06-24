using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Models
{
    [Table("TABLE5002")]
    public class MedioDePago
    {

        [Column("NWAY_PAY")]
        public int Nway_pay { get; set; }

        [Column("SDESCRIPT", TypeName = "char(30)")]
        [StringLength(30)]
        public string? Sdescript { get; set; } = string.Empty;

        [Column("DCOMPDATE")]
        public DateTime Dcomdate { get; set; }

        [Column("NSTATREGT")]
        public int Nstatregt { get; set; }


        [Column("NUSERCODE")]
        public  int? Nusercode { get; set; }
        /*public int? Nusercode { get; set; }*/

        /*[ForeignKey("NUserCode")]*/
        public virtual Users Usuario { get; set; }
    }
}
