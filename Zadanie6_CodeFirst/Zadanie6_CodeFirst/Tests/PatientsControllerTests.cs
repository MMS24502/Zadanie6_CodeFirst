using Microsoft.EntityFrameworkCore;
using Xunit;
using Zadanie6_CodeFirst.Context;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zadanie6_CodeFirst.Controllers;
using Zadanie6_CodeFirst.Models;

public class PatientsControllerTests
{
    private MasterContext CreateDbContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<MasterContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;
        
        var dbContext = new MasterContext(options);
        return dbContext;
    }

    [Fact]
    public async Task GetPatientDetails_ValidId_ReturnsPatientDetails()
    {
        var dbContext = CreateDbContext("GetPatientDetailsDB");
        dbContext.Patients.Add(new Patient { IdPatient = 1, FirstName = "John", LastName = "Doe" });
        dbContext.SaveChanges();
        
        var controller = new PatientsContoller.PatientsController(dbContext);
        
        var result = await controller.GetPatientDetails(1);
        
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }
}