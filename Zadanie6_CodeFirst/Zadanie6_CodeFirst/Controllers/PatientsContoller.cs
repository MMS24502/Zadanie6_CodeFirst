using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadanie6_CodeFirst.Context;

namespace Zadanie6_CodeFirst.Controllers;

public class PatientsContoller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly MasterContext _context;

        public PatientsController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPatientDetails(int id)
        {
            var patient = await _context.Patients
                .Where(p => p.IdPatient == id)
                .Select(p => new
                {
                    Patient = p,
                    Prescriptions = p.Prescriptions.Select(pr => new
                    {
                        pr.Date,
                        pr.DueDate,
                        Medicaments = pr.PrescriptionMedicaments.Select(pm => new 
                        {
                            MedicamentName = pm.Medicament.Name,
                            pm.Dose,
                            pm.Details
                        }).ToList()
                    }).OrderBy(pr => pr.DueDate).ToList()
                }).FirstOrDefaultAsync();

            if (patient == null)
                return NotFound("Patient not found.");

            return Ok(patient);
        }
    }
}