using Insurance.Application.Services;
using Insurance.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InsuranceController : ControllerBase
{
    private readonly IInsuranceService _insuranceService;

    public InsuranceController(IInsuranceService insuranceService)
    {
        _insuranceService = insuranceService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDemand([FromBody] CreateInsuranceDemandDto dto)
    {
        await _insuranceService.CreateInsuranceDemand(dto);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetDemand()
    {
        var demand = await _insuranceService.GetAllDemand();
       
        return Ok(demand);
    }
}
