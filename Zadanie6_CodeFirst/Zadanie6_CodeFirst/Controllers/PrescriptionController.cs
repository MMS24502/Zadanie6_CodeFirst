using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Zadanie6_CodeFirst.Context;
using Zadanie6_CodeFirst.DTOs;
using Zadanie6_CodeFirst.Models;


namespace Zadanie6_CodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly MasterContext _context;

    public PrescriptionController(MasterContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionCreationDto dto)
    {
        if (dto.Medicaments.Count > 10)
            return BadRequest("A prescription can include at most 10 medicaments.");

        if (dto.Date > dto.DueDate)
            return BadRequest("Due date must be greater than or equal to the prescription date.");

        var patient = await _context.Patients.FindAsync(dto.PatientId);
        if (patient == null)
        {
            return BadRequest("Patient not found.");
        }

        var doctor = await _context.Doctors.FindAsync(dto.DoctorId);
        if (doctor == null)
        {
            return BadRequest("Doctor not found.");
        }

        var prescription = new Prescription
        {
            IdDoctor = dto.DoctorId,
            IdPatient = dto.PatientId,
            Date = dto.Date,
            DueDate = dto.DueDate,
            PrescriptionMedicaments = dto.Medicaments.Select(m => new Prescription_Medicament
            {
                IdMedicament = m.MedicamentId,
                Dose = m.Dose,
                Details = m.Details
            }).ToList()
        };

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        return Ok(prescription.IdPrescription);
    }
}