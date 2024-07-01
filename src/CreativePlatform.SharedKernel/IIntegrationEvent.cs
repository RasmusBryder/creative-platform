using MediatR;

namespace CreativePlatform.SharedKernel;

public interface IIntegrationEvent : INotification
{
    Guid Id { get; init; }
}