using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie6_CodeFirst.Models;

public class Prescription_Medicament
{
    [Key, Column(Order = 0), ForeignKey("Medicament")]
    public int IdMedicament { get; set; }

    [Key, Column(Order = 1), ForeignKey("Prescription")]
    public int IdPrescription { get; set; }

    [Required]
    public int Dose { get; set; }

    [MaxLength(100)]
    public string Details { get; set; } // Optional based on schema

    public virtual Medicament Medicament { get; set; }
    public virtual Prescription Prescription { get; set; }
}