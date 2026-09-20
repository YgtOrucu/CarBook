using CarBook.Domain.Entities.Enums;

namespace CarBook.Dto.Dtos.ForUsersPageDtos.ReservationDto;
public class GetLoginUsersReservation
{
    public int Id { get; set; }
    public string CarName { get; set; }
    public string PickUpLocationName { get; set; }
    public string DropOffLocationName { get; set; }
    public DateTime PickUpDate { get; set; }
    public DateTime DropOffDate { get; set; }
    public TimeSpan PickUpTime { get; set; }
    public TimeSpan DropOffTime { get; set; }
    public ReservationStatus Status { get; set; }
    public decimal Price { get; set; }
}
