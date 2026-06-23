using System.Text;
using System.Text.Json;
using E_Shop.API.Options;
using E_Shop.Core.Interfaces;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace E_Shop.API.Services;

public class RabbitMqService : IMessagePublisher, IDisposable
{
	private readonly IConnection _connection;
	private readonly IChannel _channel;

	public RabbitMqService(IOptions<RabbitMqOptions> rabbitOptions)
	{
		var options = rabbitOptions.Value;

		var factory = new ConnectionFactory
		{
			HostName = options.HostName,
			Port = options.Port,
			UserName = options.UserName,
			Password = options.Password
		};

		_connection = factory.CreateConnectionAsync().Result;
		_channel = _connection.CreateChannelAsync().Result;
	}

	public async Task PublishMessage<T>(string queueName, T message)
	{
		await _channel.QueueDeclareAsync(
			queue: queueName,
			durable: false,
			exclusive: false,
			autoDelete: false);

		var json = JsonSerializer.Serialize(message);
		var body = Encoding.UTF8.GetBytes(json);

		await _channel.BasicPublishAsync(
			exchange: "",
			routingKey: queueName,
			body: body);
	}

	public void Dispose()
	{
		_channel?.Dispose();
		_connection?.Dispose();
	}
}
