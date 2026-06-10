namespace E_Shop.Core.Interfaces;
public interface IMessagePublisher
{
	Task PublishMessage<T>(string queueName, T message);
}
