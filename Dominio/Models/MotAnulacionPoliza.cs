using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Models
{
    [Table("Table13")]
    public class MotAnulacionPoliza
    {

        [Column("NNULLCODE")]
        public int Nnullcode { get; set; }

        [Column("SDESCRIPT", TypeName = "char(30)")]
        [StringLength(30)]
        public string? Sdescript { get; set; } = string.Empty;

        [Column("DCOMPDATE")]
        public DateTime Dcompdate { get; set; }


        [Column("NSTATREGT")]
        public int Nstatregt { get; set; }

        [Column("NUSERCODE")]
        public int? Nusercode { get; set; }


    }
}
