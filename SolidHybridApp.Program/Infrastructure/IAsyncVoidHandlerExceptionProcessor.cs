namespace SolidHybridApp.Program.Infrastructure;

public interface IAsyncVoidHandlerExceptionProcessor
{
	void ProcessException(Exception exception);
}
