namespace CarBook.Application.Features.Mediator.Results.ReservationResult;
public class GetReservationQueryResult
{
    public string CarName { get; set; }
    public string PickUpLocationName { get; set; }
    public string DropOffLocationName { get; set; }
    public string PickUpDate { get; set; }
    public string DropOffDate { get; set; }
    public string PickUpTime { get; set; }
    public string DropOffTime { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
}
