using CarBook.Dto.Dtos.Base;

namespace CarBook.Dto.Dtos.ForAdminPageDtos.ContactSectionDtos
{
    public class UpdateContactDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime? SendDate { get; set; }
        public bool IsStatus { get; set; }
    }
}
