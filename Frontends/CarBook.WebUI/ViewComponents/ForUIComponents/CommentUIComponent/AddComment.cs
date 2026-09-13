using CarBook.Dto.Dtos.ForUsersPageDtos.CommentSectionDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.CommentUIComponent
{
    public class AddComment() : ViewComponent
    {
        public IViewComponentResult Invoke(int Id, string UserName)
        {
            return View("~/Views/Shared/Components/ForUIComponents/CommentUIComponent/AddComment.cshtml", new AddCommmentDto(NameSurname: UserName, ImageUrl: null, MessageBody: "", BlogId: Id));
        }
    }
}
