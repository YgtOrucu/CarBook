using CarBook.Domain.Entities.Enums;

namespace CarBook.Dto.Dtos.ForAdminPageDtos.ReservationDto;

public class SendReservationEmailDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public ReservationStatus Status { get; set; }
}
