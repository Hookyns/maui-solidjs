using Microsoft.Extensions.Logging;
using RJDev.Core.DependencyInjection.Injectable;

namespace SolidHybridApp.Program.Infrastructure;

[Injectable(typeof(IAsyncVoidHandlerExceptionProcessor), ServiceLifetime.Singleton)]
public class AsyncVoidHandlerExceptionProcessor : IAsyncVoidHandlerExceptionProcessor
{
	private readonly ILogger<AsyncVoidHandlerExceptionProcessor> _logger;

	public AsyncVoidHandlerExceptionProcessor(ILogger<AsyncVoidHandlerExceptionProcessor> logger)
	{
		_logger = logger;
	}

	public void ProcessException(Exception exception)
	{
		_logger.LogError(exception, "An unhandled exception has occurred while executing the operation.");
	}
}
