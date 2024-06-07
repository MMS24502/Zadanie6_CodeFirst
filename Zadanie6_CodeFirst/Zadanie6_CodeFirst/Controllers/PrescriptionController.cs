using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Zadanie6_CodeFirst.Context;

namespace Zadanie6_CodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController
{
    private readonly MasterContext _context;

    public PrescriptionController(MasterContext context)
    {
        _context = context;
    }

    /*[HttpGet]
    public IActionResult GetPacjent()
    {
        return Ok();
    }*/
}