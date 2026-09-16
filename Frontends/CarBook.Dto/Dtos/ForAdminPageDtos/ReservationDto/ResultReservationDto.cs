namespace CarBook.Dto.Dtos.ForAdminPageDtos.ReservationDto;

public class ResultReservationDto
{
    public int CarName { get; set; }
    public int PickUpLocationName { get; set; }
    public int DropOffLocationName { get; set; }
    public string PickUpDate { get; set; }
    public string DropOffDate { get; set; }
    public string PickUpTime { get; set; }
    public string DropOffTime { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }
}
