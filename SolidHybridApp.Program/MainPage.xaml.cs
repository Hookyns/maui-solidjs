namespace SolidHybridApp.Program;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		// BindingContext = this;

#if DEBUG
		WebView.HostPage = "https://localhost:5001";
#else
		WebView.HostPage = "wwwroot/index.html";
#endif
	}
}
