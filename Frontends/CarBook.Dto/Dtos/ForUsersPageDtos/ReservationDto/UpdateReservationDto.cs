namespace CarBook.Dto.Dtos.ForUsersPageDtos.ReservationDto;

public class UpdateReservationDto
{
    public int Id { get; set; }
    public DateTime PickUpDate { get; set; }
    public TimeSpan PickUpTime { get; set; }
    public DateTime DropOffDate { get; set; }
    public TimeSpan DropOffTime { get; set; }
}