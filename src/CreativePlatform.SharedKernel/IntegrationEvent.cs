namespace CreativePlatform.SharedKernel;

public abstract record IntegrationEvent(Guid Id) : IIntegrationEvent;