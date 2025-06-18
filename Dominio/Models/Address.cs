
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.Models
{
    [Table("ADDRESS")]
    public class Address
    {
        [Column("NRECOWNER")]
        public int Nrecowner { get; set; }

        [Column("SKEYADDRESS", TypeName = "char(30)")]
        [StringLength(30)]
        public string Skeyaddress { get; set; } = null!;

        [Column("DEFFECDATE")]
        public DateTime Deffecdate { get; set; }

        [Column("SINFOR", TypeName = "char(1)")]
        [StringLength(1)]
        public string Sinfor { get; set; } = null!;

        [Column("SSTREET", TypeName = "char(40)")]
        [StringLength(40)]
        public string Sstreet { get; set; } = null!;

        [Column("NHEIGHT")]
        public int Nheight { get; set; }

        [Column("SBUILD")]
        [StringLength(10)]
        public string? Sbuild { get; set; }

        [Column("NFLOOR")]
        public int? Nfloor { get; set; }

        [Column("SDEPARTMENT")]
        [StringLength(10)]
        public string? Sdepartment { get; set; }

        [Column("SZONE", TypeName = "char(20)")]
        [StringLength(20)]
        public string? Szone { get; set; }

        [Column("NLOCAL")]
        public int Nlocal { get; set; }

        [Column("NMUNICIPALITY")]
        public int Nmunicipality { get; set; }

        [Column("NPROVINCE")]
        public int Nprovince { get; set; }

        [Column("SE_MAIL", TypeName = "char(60)")]
        [StringLength(60)]
        public string? SeMail { get; set; }

        [Column("NBRANCH")]
        public int? Nbranch { get; set; }

        [Column("NPRODUCT")]
        public int? Nproduct { get; set; }

        [Column("NPOLICY")]
        public int? Npolicy { get; set; }

        [Column("SCLIENT", TypeName = "char(14)")]
        [StringLength(14)]
        public string? Sclient { get; set; } = null!;

        [Column("DCOMPDATE")]
        public DateTime Dcompdate { get; set; }

        [Column("NUSERCODE")]
        public int? Nusercode { get; set; }

        [Column("SZIP_CODE", TypeName = "char(8)")]
        [StringLength(8)]
        public string? SzipCode { get; set; }
    }
}
