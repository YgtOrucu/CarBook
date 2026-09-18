namespace CarBook.Application.Features.Mediator.Results.ReservationResult;

public class GetReservationFormValuesQueryResult
{
    public List<GetCarDropdownDto> Cars { get; set; }
    public List<GetLocationDropdownDto> PickUpLocations { get; set; }
    public List<GetLocationDropdownDto> DropOffLocations { get; set; }
}

public class GetLocationDropdownDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class GetCarDropdownDto
{
    public int Id { get; set; }
    public string? BrandName { get; set; }
    public string? Model { get; set; }
}