namespace Insurance.Domain.Dto;

public class InsuranceDemandDto
{
    public string Title { get;  set; }
    public List<CoverageDemandResponseDto> CoverageDemandResponseDtos { get;  set; }
    public double TotalPremium { get;  set; }


}