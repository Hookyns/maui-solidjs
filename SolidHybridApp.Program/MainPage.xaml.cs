// using HybridWebView;

using System.Text.Json;
using Microsoft.AspNetCore.Components.WebView;
using Microsoft.JSInterop;

namespace SolidHybridApp.Program;

public partial class MainPage : ContentPage
{
#if MACCATALYST || IOS
	class WKHandler : WebKit.WKScriptMessageHandler
	{
		// https://stackoverflow.com/questions/58754541/angular-html5-to-ios-wkwebview-communication
		public override void DidReceiveScriptMessage(
			WebKit.WKUserContentController userContentController,
			WebKit.WKScriptMessage message
		)
		{
			var json = message.Body.ToString();
		}
	}
#endif

	public MainPage()
	{
		InitializeComponent();

		// #if DEBUG
		// 		UiHybridWebView.EnableWebDevTools = true;
		// #endif

		BindingContext = this;

		WebView.BlazorWebViewInitialized += OnBlazorWebViewInitialized;

		WebView.HandlerChanged += (sender, args) =>
		{
			// // https://github.com/Eilon/MauiHybridWebView/blob/main/HybridWebView/Platforms/Windows/HybridWebView.Windows.cs#L124
			// await InitializeHybridWebView();
			// Navigate(StartPath);
		};
	}

	// private void Wv2_WebMessageReceived(WebView2 sender, CoreWebView2WebMessageReceivedEventArgs args)
	// {
	// 	var message = args.TryGetWebMessageAsString();
	//
	// 	WebView.TryDispatchAsync(async services =>
	// 	{
	// 		var runtime = services.GetService<IJSRuntime>();
	//
	// 		if (runtime != null)
	// 		{
	// 			await runtime.InvokeAsync<bool>("window.alert", "Hello from C#!");
	// 		}
	// 	});
	// }

	record Test(string Bar);

	[JSInvokable]
	public static void DispatchInit(JsonDocument arg)
	{
		var test = arg.Deserialize<Test>(new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
		// var test = arg.Deserialize<Test>();
		var y = 2;
	}

	[JSInvokable]
	public static void DispatchMessage(string messageType, string messageJson)
	{
		var y = 1;
	}

	private async void OnBlazorWebViewInitialized(object? sender, BlazorWebViewInitializedEventArgs e)
	{
#if WINDOWS
		var webView = ((Microsoft.UI.Xaml.Controls.WebView2)WebView.Handler.PlatformView);
		webView.CoreWebView2.Settings.IsWebMessageEnabled = true;
		webView.WebMessageReceived += (
			Microsoft.UI.Xaml.Controls.WebView2 sender,
			Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs args
		) =>
		{
			//__bwv:["BeginInvokeDotNet","2","__dispatch","Dispatch",0,"[1,2,3,\"foo\",{\"bar\":\"nice\"}]"]
			var str = args.TryGetWebMessageAsString();
			if (str.StartsWith("__bwv:[\"BeginInvokeDotNet\""))
			{
				var asJson = args.WebMessageAsJson;
				var rawMessage = JsonSerializer.Deserialize<JsonElement[]>(str.Substring("__bwv:".Length));
				var parameters = JsonSerializer.Deserialize<JsonElement[]>(rawMessage[5].GetString());
				var y = 1;
			}
			// WebView.TryDispatchAsync(async services =>
			// {
			// 	var runtime = services.GetService<IJSRuntime>();
			//
			// 	if (runtime != null)
			// 	{
			// 		await runtime.InvokeAsync<bool>("window.alert", "Hello from C#!");
			// 	}
			// });
		};
#elif MACCATALYST || IOS
			((WebKit.WKWebView)Handler.PlatformView).Configuration.UserContentController.AddScriptMessageHandler(new WKHandler(), "__dispatch");
#elif ANDROID
#elif TIZEN
#endif



		// e.WebView;

		// await WebView.TryDispatchAsync(async services =>
		// {
		// 	var runtime = services.GetService<IJSRuntime>();
		//
		// 	if (runtime != null)
		// 	{
		// 		await runtime.InvokeAsync<bool>("window.alert", "Hello from C#!");
		// 	}
		// });
		// var runtime = WebView.Handler?.MauiContext?.Services.GetService<IJSRuntime>();
		//
		// if (runtime != null)
		// {
		// 	await runtime.InvokeAsync<bool>("window.alert", "Hello from C#!");
		// }
	}

	// private async void OnLoaded(object? sender, EventArgs e)
	// {
	// 	var runtime = WebView.Handler?.MauiContext?.Services.GetService<IJSRuntime>();
	//
	// 	if (runtime != null)
	// 	{
	// 		await runtime.InvokeAsync<bool>("window.alert", "Hello from C#!");
	// 	}
	// }


	// private void OnCounterClicked(object sender, EventArgs e)
	// {
	//     count++;
	//
	//     if (count == 1)
	//         CounterBtn.Text = $"Clicked {count} time";
	//     else
	//         CounterBtn.Text = $"Clicked {count} times";
	//
	//     SemanticScreenReader.Announce(CounterBtn.Text);
	// }

	// private void OnHybridWebViewRawMessageReceived(object? sender, HybridWebViewRawMessageReceivedEventArgs e)
	// {
	// 	System.Diagnostics.Debug.WriteLine($"Received message from HybridWebView: {e.Message}");
	// }

	public void GetAvailablePrinters()
	{
		System.Drawing.Printing.PrinterSettings.InstalledPrinters
			.Cast<string>()
			.ToList()
			.ForEach(x => System.Diagnostics.Debug.WriteLine(x));
	}
}
