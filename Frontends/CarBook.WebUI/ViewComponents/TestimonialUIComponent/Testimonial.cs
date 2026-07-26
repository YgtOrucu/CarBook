using CarBook.Dto.Dtos.TestimonialSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.TestimonialUIComponent
{
    public class Testimonial(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync("testimonial");

            if (response.IsSuccessStatusCode)
            {
                var values = await response.Content.ReadFromJsonAsync<List<ResultTestimonialDto>>();
                return View("~/Views/Shared/Components/TestimonialUIComponent/Testimonial.cshtml", values);
            }
            return View("~/Views/Shared/Components/TestimonialUIComponent/Testimonial.cshtml");
        }
    }
}
