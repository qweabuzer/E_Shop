
using System.Text;
using System.Text.Json;
using E_Shop.Contracts.Messages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace E_Shop.API.Services;

public class UserCreatedConsumer : BackgroundService
{
	private readonly ILogger<UserCreatedConsumer> _logger;
	private IConnection? _connection;
	private IChannel? _channel;

	public UserCreatedConsumer(ILogger<UserCreatedConsumer> logger)
	{
		_logger = logger;
	}
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		var factory = new ConnectionFactory
		{
			HostName = "localhost",
			Port = 5672,
			UserName = "guest",
			Password = "guest"
		};

		_connection = await factory.CreateConnectionAsync();
		_channel = await _connection.CreateChannelAsync();

		await _channel.QueueDeclareAsync(
			queue: "user_created",
			durable: false,
			exclusive: false,
			autoDelete: false);

		var consumer = new AsyncEventingBasicConsumer(_channel);

		consumer.ReceivedAsync += async (sender, args) =>
		{
			var body = args.Body.ToArray();
			var json = Encoding.UTF8.GetString(body);
			var message = JsonSerializer.Deserialize<UserCreatedMessage>(json);

			_logger.LogInformation("\n\nсоздан пользователь. \n ID: {UserId}, \n Время создания: {CreatedTime}", message?.UserId, message?.CreatedTime);

			await _channel.BasicAckAsync(args.DeliveryTag, false);
		};

		await _channel.BasicConsumeAsync(
			queue: "user_created",
			autoAck: false,
			consumer: consumer);

		_logger.LogInformation("consumer запущен. слушает очередь user_created");

		await Task.Delay(Timeout.Infinite, stoppingToken);
	}

	public override async Task StopAsync(CancellationToken cancellationToken)
	{
		_channel?.Dispose();
		_connection?.Dispose();

		await base.StopAsync(cancellationToken);
	}
}
