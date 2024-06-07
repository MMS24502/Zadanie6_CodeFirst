using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie6_CodeFirst.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [ForeignKey("Patient")]
    public int IdPatient { get; set; }

    [ForeignKey("Doctor")]
    public int IdDoctor { get; set; }

    public virtual Doctor Doctor { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; }
}