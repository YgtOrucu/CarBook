using CarBook.Application.Base;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ReservationCommand;

public class CreateReservationCommand : IRequest<BaseResult<object>>
{
    public int CarId { get; set; }
    public int PickUpLocationId { get; set; }
    public int DropOffLocationId { get; set; }
    public DateTime PickUpDate { get; set; }
    public DateTime DropOffDate { get; set; }
    public TimeSpan PickUpTime { get; set; }
    public TimeSpan DropOffTime { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public DateTime FullPickUpDateTime => PickUpDate.Date + PickUpTime;
    public DateTime FullDropOffDateTime => DropOffDate.Date + DropOffTime;

    public int TotalDays
    {
        get
        {
            TimeSpan duration = FullDropOffDateTime - FullPickUpDateTime;
            int days = (int)Math.Ceiling(duration.TotalDays);
            return days > 0 ? days : 1; 
        }
    }
    public decimal CalculateTotalPrice(decimal dailyAmount)
    {
        return TotalDays * dailyAmount;
    }
}
