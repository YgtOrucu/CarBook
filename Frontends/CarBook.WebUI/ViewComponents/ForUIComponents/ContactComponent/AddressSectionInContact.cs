using CarBook.Dto.Dtos.ForUsersPageDtos.ContactSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.ContactComponent
{
    public class AddressSectionInContact(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync("footerAddress/GetFooterAddressForPresantation");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<ResultAddressSectionInContactDto>();
                return View("~/Views/Shared/Components/ForUIComponents/ContactComponent/AddressSectionInContact.cshtml", value);
            }

            return View("~/Views/Shared/Components/ForUIComponents/ContactComponent/AddressSectionInContact.cshtml");
        }
    }
}
