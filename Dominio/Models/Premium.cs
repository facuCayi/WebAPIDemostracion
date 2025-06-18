using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dominio.Models
{
    [Table("PREMIUM")]
    public class Premium
    {
        [Column("NBRANCH")]
        public int Nbranch { get; set; }

        [Column("NPRODUCT")]
        public int Nproduct { get; set; }

        [Column("NPOLICY")]
        public int Npolicy { get; set; }

        [Column("NRECEIPT")]
        public int Nreceipt { get; set; }

        [Column("DEFFECDATE")]
        public DateTime Deffecdate { get; set; }

        [Column("DISSUEDAT")]
        public DateTime Dissuedat { get; set; }

        [Column("DEXPIRDAT")]
        public DateTime Dexpirdat { get; set; }

        [Column("NWAY_PAY")]
        public int Nway_pay { get; set; }

        [Column("NPREMIUM")]
        public int Npremium { get; set; }

        [Column("NBALANCE")]
        public int Nbalance { get; set; }

        [Column("NSTATUS_PRE")]
        public int Nstatus_pre { get; set; }

        [Column("NSTATUS_PAY")]
        public int? Nstatus_pay { get; set; }

        [Column("DNULLDATE")]
        public DateTime? Dnulldate { get; set; }

        [Column("NNULLCODE")]
        public int? Nnullcode { get; set; }

        [Column("NUSERCODE")]
        public int? Nusercode { get; set; }

    }
}
