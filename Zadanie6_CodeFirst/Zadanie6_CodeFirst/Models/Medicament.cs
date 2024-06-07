using System.ComponentModel.DataAnnotations;

namespace Zadanie6_CodeFirst.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Description { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Type { get; set; }
    
    public virtual ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; }
}