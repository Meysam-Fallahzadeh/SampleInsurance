namespace Insurance.Domain.Dto;

public class CreateInsuranceDemandDto
{
    public string Title { get; set; }
    public List<CoverageDto> CoverageDtos { get; set; }

    public bool IsInvalid => string.IsNullOrEmpty(Title) || CoverageDtos is null || !CoverageDtos.Any();
}   