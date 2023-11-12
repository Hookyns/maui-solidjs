namespace SolidHybridApp.Program.Infrastructure;

public static class AppServiceProvider
{
	public static IServiceProvider Services { get; private set; } = new ServiceCollection().BuildServiceProvider();

	internal static void SetServiceProvider(IServiceProvider services)
	{
		Services = services;
	}
}
