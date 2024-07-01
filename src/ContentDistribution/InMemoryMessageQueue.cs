using CreativePlatform.SharedKernel;
using System.Threading.Channels;

namespace ContentDistribution;

/// <summary>
/// Simple in-memory message queue to demonstrate producer/consumer pattern.
/// </summary>
internal sealed class InMemoryMessageQueue
{
    private readonly Channel<IIntegrationEvent> _channel = Channel.CreateUnbounded<IIntegrationEvent>();

    public ChannelReader<IIntegrationEvent> Reader => _channel.Reader;

    public ChannelWriter<IIntegrationEvent> Writer => _channel.Writer;
}