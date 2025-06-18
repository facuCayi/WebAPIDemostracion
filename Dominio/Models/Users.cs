using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Models
{
    [Table("USUARIOS")]
    public class Users
    {

        [Column("NUSERCODE")]
        public int Nusercode { get; set; }

        [Column("SINITIALS", TypeName = "char(12)")]
        [StringLength(12)]
        public string? Sinitials { get; set; } = string.Empty;


        [Column("NSTATREGT")]
        public int Nstatregt { get; set; }
    }
}
