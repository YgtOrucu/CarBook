using CarBook.Dto.Dtos.ForAdminPageDtos.CarPricingSectionDtos;
using CarBook.Dto.Dtos.ForAdminPageDtos.CarSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CarPricingController(IHttpClientFactory httpClientFactory) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = httpClientFactory.CreateClient("CarBookAPI");
        var response = await client.GetAsync("carpricing/timeperiod");
        if (response.IsSuccessStatusCode)
        {
            var values = await response.Content.ReadFromJsonAsync<List<ResultCarPricingWithTimePeriodDto>>();
            return View(values);
        }
        return View(new List<ResultCarPricingWithTimePeriodDto>());
    }

    [HttpGet]
    public async Task<IActionResult> CreateCarPricing()
    {
        ViewBag.CarValues = await GetCarList();
        return View();
    }

    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> CreateCarPricing(CreateCarPricingDto dto)
    {
        var client = httpClientFactory.CreateClient("CarBookAPI");
        var response = await client.PostAsJsonAsync("carpricing", dto);

        if (response.IsSuccessStatusCode)
            return RedirectToAction("Index");

        ViewBag.CarValues = await GetCarList();
        return View(dto);
    }

    private async Task<List<ResultCarDto>> GetCarList()
    {
        var client = httpClientFactory.CreateClient("CarBookAPI");
        var response = await client.GetAsync("car/getBrand");
        if (response.IsSuccessStatusCode)
        {
            var values = await response.Content.ReadFromJsonAsync<List<ResultCarDto>>();
            return values ?? new List<ResultCarDto>();
        }
        ViewBag.CarValues = await GetCarList();
        return new List<ResultCarDto>();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCarPricing(int carId)
    {
        ViewBag.CarValues = await GetCarList();
        var client = httpClientFactory.CreateClient("CarBookAPI");
        var response = await client.GetAsync($"carpricing/{carId}");
        if (response.IsSuccessStatusCode)
        {
            var value = await response.Content.ReadFromJsonAsync<UpdateCarPricingDto>();
            return View(value);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCarPricing(UpdateCarPricingDto dto)
    {
        var client = httpClientFactory.CreateClient("CarBookAPI");
        var response = await client.PutAsJsonAsync("carpricing", dto);
        if (response.IsSuccessStatusCode)
            return RedirectToAction("Index");

        ViewBag.CarValues = await GetCarList();
        return View(dto);
    }

    public async Task<IActionResult> RemoveCarPricing(int carId)
    {
        var client = httpClientFactory.CreateClient("CarBookAPI");
        await client.DeleteAsync($"carpricing/{carId}");
        return RedirectToAction("Index");
    }
}