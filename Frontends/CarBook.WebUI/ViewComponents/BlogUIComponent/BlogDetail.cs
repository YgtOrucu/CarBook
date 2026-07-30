using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogUIComponent
{
    public class BlogDetail() : ViewComponent
    {
        public IViewComponentResult Invoke(int Id)
        {
            return View("~/Views/Shared/Components/BlogUIComponent/BlogDetail.cshtml", Id);
        }
    }
}