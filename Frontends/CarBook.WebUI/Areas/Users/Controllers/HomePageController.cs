using CarBook.Dto.Dtos.ForUsersPageDtos.ReservationDto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
// Gerekli DTO namespace'lerini projene göre buraya eklediğinden emin ol
// using CarBook.Dto.Dtos.ForUsersPageDtos.ReservationDto; 

namespace CarBook.WebUI.Areas.Users.Controllers
{
    [Area("Users")]
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            // 1. Örnek Lokasyon Verileri (Alış ve İade için ortak kullanılabilir)
            var dummyLocations = new List<ResultLocationDto>
            {
                new ResultLocationDto { Id = 1, Name = "İstanbul Havalimanı (IST)" },
                new ResultLocationDto { Id = 2, Name = "Sabiha Gökçen Havalimanı (SAW)" },
                new ResultLocationDto { Id = 3, Name = "Ankara Esenboğa Havalimanı" },
                new ResultLocationDto { Id = 4, Name = "İzmir Adnan Menderes Havalimanı" }
            };

            ViewBag.PickUpLocation = dummyLocations;
            ViewBag.DropOffLocation = dummyLocations;

            // 2. Örnek Araç Verileri (Resim önizleme testi için görseller eklendi)
            var dummyCars = new List<ResultCarDtoForReservation>
            {
                new ResultCarDtoForReservation
                {
                    Id = 1,
                    BrandName = "Renault",
                    Model = "Clio 1.0",
                    CoverImageUrl = "/carbook-master/images/car-1.jpg"
                },
                new ResultCarDtoForReservation
                {
                    Id = 2,
                    BrandName = "Fiat",
                    Model = "Egea 1.6",
                    CoverImageUrl = "/carbook-master/images/car-1.jpg"
                },
                new ResultCarDtoForReservation
                {
                    Id = 3,
                    BrandName = "Volkswagen",
                    Model = "Passat 2.0",
                    CoverImageUrl = "/carbook-master/images/car-1.jpg"
                }
            };

            ViewBag.Car = dummyCars;

            return View();
        }
    }
}