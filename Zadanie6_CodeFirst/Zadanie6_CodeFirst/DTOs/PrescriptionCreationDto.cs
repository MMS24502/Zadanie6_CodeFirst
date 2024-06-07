namespace Zadanie6_CodeFirst.DTOs;

public class PrescriptionCreationDto
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<PrescriptionMedicamentDto> Medicaments { get; set; } 
}