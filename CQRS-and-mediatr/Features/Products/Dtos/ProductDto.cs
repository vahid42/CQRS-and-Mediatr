namespace CQRS_and_mediatr.Features.Products.Dtos
{
    public record ProductDto(Guid Id, string Name, string Description, decimal Price);

}
