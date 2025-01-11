using CQRS_and_mediatr.Features.Products.Dtos;
using MediatR;

namespace CQRS_and_mediatr.Features.Products.Queries.Get
{
    public record GetProductQuery(Guid Id) : IRequest<ProductDto>;
}
