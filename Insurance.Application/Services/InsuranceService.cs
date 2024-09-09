using Insurance.Domain.Dto;
using Insurance.Domain.Entities;
using Insurance.Domain.RepositoriesInterface;

namespace Insurance.Application.Services;

public class InsuranceService: IInsuranceService
{
    private readonly IInsuranceDemandRepository _demandRepository;
    private readonly IInsuranceCoverageRepository _coverageRepository;

    public InsuranceService(IInsuranceDemandRepository demandRepository, IInsuranceCoverageRepository coverageRepository)
    {
        _demandRepository = demandRepository;
        _coverageRepository = coverageRepository;
    }

    public async Task<ApplicationResponse> CreateInsuranceDemand(CreateInsuranceDemandDto dto)
    {
        if (dto.IsInvalid)
            throw new ArgumentException("Invalid request");

        var demand = new InsuranceDemand(dto.Title);

        foreach (var coverageDto in dto.CoverageDtos)
        {
            var coverage =await GetCoverage(coverageDto.CoverageId);

            demand.AddCoverage(coverage, coverageDto.Amount);
        }

        await _demandRepository.AddAsync(demand);

        await _demandRepository.SaveChangesAsync();

        return new ApplicationResponse(true);
    }



    public async Task<ApplicationResponse<IEnumerable<InsuranceDemandDto>>> GetAllDemand()
    {
        var demands= await _demandRepository.GetAllAsync();

        var result= demands.Select(d => new InsuranceDemandDto()
        {
            Title = d.Title,
            CoverageDemandResponseDtos = d.Coverages.Select(c=>new CoverageDemandResponseDto()
            {
                CoverageType = c.Coverage.CoverageType,
                Premium = c.CalculatePremium()

            }).ToList(),
            TotalPremium = d.TotalPremium,
        }).ToList();

        return new ApplicationResponse<IEnumerable<InsuranceDemandDto>>(result);
    }

    private async Task<InsuranceCoverage> GetCoverage(int id)
    {
        var coverage = await _coverageRepository.GetByIdAsync(id);

        return coverage ?? throw new Exception("CoverageId is invalid");
    }
}