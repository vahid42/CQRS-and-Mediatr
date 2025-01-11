using CQRS_and_mediatr.DB;
using CQRS_and_mediatr.Features.Products.Queries.Get;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_and_mediatr.Features.Products.Commands.Update
{
    public class UpdateProductCommandHandler (AppDbContext context)
        : IRequestHandler<UpdateProductCommand, bool>
    {
 
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id);
            if (product == null)
            {
                return false;
            }
            else
            {
                 context.Products.Update(product);
                 context.SaveChanges();
                return true;
            }
           
        }
    }
}
