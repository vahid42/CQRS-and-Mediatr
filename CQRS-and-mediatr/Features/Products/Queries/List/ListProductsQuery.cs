using CQRS_and_mediatr.Features.Products.Dtos;
using MediatR;

namespace CQRS_and_mediatr.Features.Products.Queries.List
{
    public record ListProductsQuery : IRequest<List<ProductDto>>;
}
