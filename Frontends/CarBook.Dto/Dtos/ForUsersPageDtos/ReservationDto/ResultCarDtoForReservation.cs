using CarBook.Dto.Dtos.Base;

namespace CarBook.Dto.Dtos.ForUsersPageDtos.ReservationDto
{
    public class ResultCarDtoForReservation : BaseDto
    {
        public string? BrandName { get; set; }
        public string? Model { get; set; }
        public string? CoverImageUrl { get; set; }
    }
}
