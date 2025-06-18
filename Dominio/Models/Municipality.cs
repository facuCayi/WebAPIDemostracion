using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.Models
{
    [Table("MUNICIPALITY")]
    public class Municipality
    {

        [Column("NMUNICIPALITY")]
        public int Nmunicipality { get; set; }


        [Column("SDESCRIPT", TypeName = "char(30)")]
        [StringLength(30)]
        public string? Sdescript { get; set; }

        [Column("NPROVINCE")]
        [ForeignKey(nameof(Provincia))]
        public int? Nprovince { get; set; }

        public virtual Province Provincia { get; set; }
    }
}
