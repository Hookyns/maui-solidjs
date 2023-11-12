using SolidHybridApp.Program.Infrastructure;

namespace SolidHybridApp.Program;

public partial class App : Application
{
	public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();

		AppServiceProvider.SetServiceProvider(serviceProvider);

		MauiExceptions.UnhandledException += (sender, args) =>
		{
			if (MainPage is not null)
			{
				// MainPage.DisplayAlert("Error", args.ExceptionObject.ToString(), "Cancel");
			}

			// TODO: Log
		};

		MainPage = serviceProvider.GetService<MainPage>() as Page ?? new CSharpErrorPage();
	}
}
