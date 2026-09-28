using CarBook.Domain.Entities.Enums;

namespace CarBook.Application.Features.Mediator.Results.ReservationResult;
public class GetReservationQueryResult
{
    public int Id { get; set; }
    public string CarName { get; set; }
    public string PickUpLocationName { get; set; }
    public string DropOffLocationName { get; set; }
    public DateTime PickUpDate { get; set; }
    public DateTime DropOffDate { get; set; }
    public TimeSpan PickUpTime { get; set; }
    public TimeSpan DropOffTime { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public decimal Price { get; set; }
    public ReservationStatus Status { get; set; }
}
