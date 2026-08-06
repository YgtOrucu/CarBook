using CarBook.Dto.Dtos.ForUsersPageDtos.TestimonialSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.TestimonialUIComponent
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
                return View("~/Views/Shared/Components/ForUIComponents/TestimonialUIComponent/Testimonial.cshtml", values);
            }
            return View("~/Views/Shared/Components/ForUIComponents/TestimonialUIComponent/Testimonial.cshtml");
        }
    }
}
