using Domain.Models.Creates;
using Domain.Models.Update;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces;

public interface IDriverService
{
    Task<IActionResult> GetDrivers();
    Task<IActionResult> GetDriver(Guid id);
    Task<IActionResult> CreateDriver(DriverCreateModel model);
    Task<IActionResult> UpdateDriver(Guid id, DriverUpdateModel model);
    Task<IActionResult> DeleteDriver(Guid id);
    
}