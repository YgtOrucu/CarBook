using CarBook.Dto.Dtos.ForUsersPageDtos.BlogDetailSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.BlogUIComponent
{
    public class BlogDetail() : ViewComponent
    {
        public IViewComponentResult Invoke(int Id, string UserName, string Email)
        {
            var model = new ForCommentInBlogDetailPageDto
            {
                Id = Id,
                UserName = UserName,
                Email = Email
            };

            return View("~/Views/Shared/Components/ForUIComponents/BlogUIComponent/BlogDetail.cshtml", model);
        }
    }
}