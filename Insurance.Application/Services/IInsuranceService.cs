using Insurance.Domain.Dto;
using Insurance.Domain.Entities;

namespace Insurance.Application.Services;

public interface IInsuranceService
{
      Task<ApplicationResponse> CreateInsuranceDemand(CreateInsuranceDemandDto dto);

      Task<ApplicationResponse<IEnumerable<InsuranceDemandDto>>> GetAllDemand();
}