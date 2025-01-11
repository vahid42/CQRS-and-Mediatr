using MediatR;

namespace CQRS_and_mediatr.Features.Products.Notifications
{
    public record ProductCreatedNotification(Guid Id) : INotification;

}
