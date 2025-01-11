using CQRS_and_mediatr.DB;
using CQRS_and_mediatr.Features.Products.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_and_mediatr.Features.Products.Queries.List
{
    public class ListProductsQueryHandler(AppDbContext context) : IRequestHandler<ListProductsQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            return await context.Products
                .Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price))
                .ToListAsync();
        }
    }
}
