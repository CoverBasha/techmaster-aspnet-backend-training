using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_01_ef_core_modeling_drills.Entities
{
    public class PaymentSummary
    {
        [Key]
        [ForeignKey(nameof(Enrollment))]
        public Guid EnrollmentId { get; set; }
        [Required]
        public decimal TotalRequired { get; set; }
        [Required]
        public decimal TotalPaid { get; set; }
        public decimal RemainingAmount => TotalRequired - TotalPaid;
        [Required]
        public PaymentStatus PaymentStatus { get; set; }


        //Navigation property
        public Enrollment Enrollment { get; set; }
    }

    public enum PaymentStatus
    {
        Paid,
        PartiallyPaid,
        Pending
    }
}
