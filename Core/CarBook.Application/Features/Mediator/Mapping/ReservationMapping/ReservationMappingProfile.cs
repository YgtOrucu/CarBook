using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.ReservationCommand;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Mapping.ReservationMapping;

public class ReservationMappingProfile : Profile
{
    public ReservationMappingProfile()
    {
        CreateMap<CreateReservationCommand, Reservation>().ForMember(opt => opt.Phone, desc => desc.MapFrom(src => src.PhoneNumber));
        CreateMap<UpdateReservationCommand, Reservation>();
    }
}
