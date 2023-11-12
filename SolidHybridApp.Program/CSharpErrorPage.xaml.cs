namespace SolidHybridApp.Program;

public partial class CSharpErrorPage : ContentPage
{
	// public string Message { get; set; } = "C# Error Page";

	public CSharpErrorPage()
	{
		InitializeComponent();

		Message.Text = "Unexpected error occured.";
	}
}
