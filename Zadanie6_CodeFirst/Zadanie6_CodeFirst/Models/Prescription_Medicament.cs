using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie6_CodeFirst.Models;

public class Prescription_Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    public Medicament Medicament { get; set; }

    [Key]
    public int IdPrescription { get; set; }
    public Prescription Prescription { get; set; }

    [Required]
    public int Dose { get; set; }

    [MaxLength(100)]
    public string Details { get; set; }

    
    
}