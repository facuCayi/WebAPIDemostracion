using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Models
{
    [Table("POLIZA_HISTORY")]
    public class PolicyHistory
    {

        [Column("NBRANCH")]
        [ForeignKey(nameof(Branch))]
        public int Nbranch { get; set; }

        [Column("NPRODUCT")]
        public int Nproduct { get; set; }

        [Column("NPOLICY")]
        public int Npolicy { get; set; }

        [Column("NMOVMENT")]
        public int Nmovment { get; set; }

        [Column("SCLIENT", TypeName = "char(14)")]
        [StringLength(14)]
        [ForeignKey(nameof(Client))]
        public string Sclient { get; set; } = null!;

        [Column("DDATE_ORIGI")]
        public DateTime Ddate_origi { get; set; }

        [Column("DSTARTDATE")]
        public DateTime Dstartdate { get; set; }

        [Column("DEXPIRDAT")]
        public DateTime Dexpirdat { get; set; }

        [Column("NCAPITAL")]
        public int Ncapital { get; set; }

        [Column("NWAY_PAY")]
        [ForeignKey(nameof(Way_pay))]
        public int Nway_pay { get; set; }

        [Column("DCOMPDATE")]
        public DateTime Dcomdate { get; set; }

        [Column("DNULLDATE")]
        public DateTime? Dnulldate { get; set; }

        [Column("NNULLCODE")]
        [ForeignKey(nameof(NullCode))]
        public int? Nnullcode { get; set; }

        [Column("NUSERCODE")]
        [ForeignKey(nameof(Usuario))]
        public int? Nusercode { get; set; }

        public virtual Client Client { get; set; }

        public virtual MedioDePago Way_pay { get; set; }

        public virtual MotAnulacionPoliza NullCode { get; set; }

        public virtual Users Usuario { get; set; }

        public virtual RamoComercial Branch { get; set; }

        public virtual Productmaster Product { get; set; }

    }
}
