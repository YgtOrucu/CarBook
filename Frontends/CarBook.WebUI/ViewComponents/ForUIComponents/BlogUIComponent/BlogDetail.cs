using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.BlogUIComponent
{
    public class BlogDetail() : ViewComponent
    {
        public IViewComponentResult Invoke(int Id)
        {
            return View("~/Views/Shared/Components/ForUIComponents/BlogUIComponent/BlogDetail.cshtml", Id);
        }
    }
}