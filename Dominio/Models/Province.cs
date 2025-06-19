using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.Models
{
    [Table("PROVINCE")]
    public class Province
    {

        [Column("NPROVINCE")]
        public int Nprovince { get; set; }

        [Column("SDESCRIPT", TypeName = "char(30)")]
        [StringLength(30)]
        public string? Sdescript { get; set; }

        [Column("DCOMPDATE")]
        public DateTime Dcompdate { get; set; }

        [Column("NUSERCODE")]
        [ForeignKey(nameof(Usuario))]
        public int? Nusercode { get; set; }

        public virtual Users Usuario { get; set; }
        
    }

}
