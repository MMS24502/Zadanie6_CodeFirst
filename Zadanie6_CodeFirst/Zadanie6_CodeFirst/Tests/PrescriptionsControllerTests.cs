using Microsoft.EntityFrameworkCore;
using Xunit;
using Zadanie6_CodeFirst.Context;
using System;
using Microsoft.AspNetCore.Mvc;
using Zadanie6_CodeFirst.Models;
using Zadanie6_CodeFirst.Controllers;
using Zadanie6_CodeFirst.DTOs;

public class PrescriptionsControllerTests
{
    private MasterContext CreateDbContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<MasterContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        return new MasterContext(options);
    }

    [Fact]
    public async Task PostPrescription_ValidData_ReturnsCreatedResult()
    {
        // Setup the DbContext
        var dbContext = CreateDbContext("PostPrescriptionDB");
        dbContext.Doctors.Add(new Doctor { IdDoctor = 1 });
        dbContext.Patients.Add(new Patient { IdPatient = 1 });
        dbContext.SaveChanges();

        // Setup the Controller
        var controller = new PrescriptionController(dbContext);
        var newPrescription = new PrescriptionCreationDto
        {
            DoctorId = 1,
            PatientId = 1,
            Date = DateTime.Now,
            DueDate = DateTime.Now.AddDays(10),
            Medicaments = new List<PrescriptionMedicamentDto> {
                new PrescriptionMedicamentDto { MedicamentId = 1, Dose = 10, Details = "Take daily" }
            }
        };

        // Act
        var result = await controller.CreatePrescription(newPrescription);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}