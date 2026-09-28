namespace CarBook.Dto.Dtos.ForAdminPageDtos.ReservationDto;

public class GenerateReservationMessageDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string CarName { get; set; }
    public string PickUpLocation { get; set; }
    public string DropOffLocation { get; set; }
    public string PickUpDateTime { get; set; }
    public string DropOffDateTime { get; set; }
    public string Price { get; set; }
}