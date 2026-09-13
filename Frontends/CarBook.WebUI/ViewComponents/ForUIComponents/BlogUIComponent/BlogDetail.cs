using CarBook.Dto.Dtos.ForUsersPageDtos.BlogDetailSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.BlogUIComponent
{
    public class BlogDetail() : ViewComponent
    {
        public IViewComponentResult Invoke(int Id, string UserName)
        {
            var model = new ForCommentInBlogDetailPageDto
            {
                Id = Id,
                UserName = UserName
            };

            return View("~/Views/Shared/Components/ForUIComponents/BlogUIComponent/BlogDetail.cshtml", model);
        }
    }
}