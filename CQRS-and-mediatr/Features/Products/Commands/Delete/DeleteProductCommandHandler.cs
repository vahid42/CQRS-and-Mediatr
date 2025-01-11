using CQRS_and_mediatr.DB;
using CQRS_and_mediatr.Domain;
using MediatR;

namespace CQRS_and_mediatr.Features.Products.Commands.Delete
{
    public class DeleteProductCommandHandler(AppDbContext context) : IRequestHandler<DeleteProductCommand,bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await context.Products.FindAsync(request.Id);
                if (product == null) return false;
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

               return false;
            }
            return true;
           
        }
    }
}
