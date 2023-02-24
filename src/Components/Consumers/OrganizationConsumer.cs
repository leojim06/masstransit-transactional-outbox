using Components.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Components.Consumers
{
    public class MessageSubmittedConsumer
        : IConsumer<MessageSubmitted>
    {
        private readonly ILogger<MessageSubmittedConsumer> _logger;

        public MessageSubmittedConsumer(ILogger<MessageSubmittedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<MessageSubmitted> context)
        {
            var message = context.Message;
            _logger.LogInformation("Message: {name}", message.Name);
            return Task.CompletedTask;
        }
    }
}
