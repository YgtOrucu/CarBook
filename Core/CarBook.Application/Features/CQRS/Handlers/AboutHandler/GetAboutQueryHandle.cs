using CarBook.Application.Features.CQRS.Results.AboutResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler
{
    public class GetAboutQueryHandle
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandle(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var abouts = await _repository.GetAllAsync();
            var result = new List<GetAboutQueryResult>();
            foreach (var about in abouts)
            {
                result.Add(new GetAboutQueryResult
                {
                    Id = about.Id,
                    Title = about.Title,
                    Description = about.Description,
                    CreatedDate = about.CreatedDate,
                    CreatedBy = about.CreatedBy,
                    UpdatedDate = about.UpdatedDate,
                    UpdatedBy = about.UpdatedBy,
                    ImageUrl = about.ImageUrl,
                    IsDeleted = about.IsDeleted
                });
            }
            return result;
        }
    }
}
