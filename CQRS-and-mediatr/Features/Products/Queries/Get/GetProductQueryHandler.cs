﻿using CQRS_and_mediatr.DB;
using CQRS_and_mediatr.Features.Products.Dtos;
using MediatR;

namespace CQRS_and_mediatr.Features.Products.Queries.Get
{
    public class GetProductQueryHandler(AppDbContext context)
    : IRequestHandler<GetProductQuery, ProductDto?>
    {
        public async Task<ProductDto?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id);
            if (product == null)
            {
                return null;
            }
            return new ProductDto(product.Id, product.Name, product.Description, product.Price);
        }
    }
}
