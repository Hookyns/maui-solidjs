using System.Text.Json;
using Microsoft.AspNetCore.Components.WebView;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.JSInterop;

namespace SolidHybridApp.Program.Infrastructure.WebViewMessageDispatching;

public class WebViewMessageDispatcher : IDisposable
{
	private readonly List<BlazorWebView> _webViews = new();

	private static readonly JsonSerializerOptions s_jsonDeserializeOptions = new()
	{
		PropertyNameCaseInsensitive = true
	};

	public void Register(BlazorWebView webView)
	{
		_webViews.Add(webView);

		webView.BlazorWebViewInitialized += OnBlazorWebViewInitialized;
		// webView.HandlerChanged += (sender, args) =>
		// {
		// 	// // https://github.com/Eilon/MauiHybridWebView/blob/main/HybridWebView/Platforms/Windows/HybridWebView.Windows.cs#L124
		// 	// await InitializeHybridWebView();
		// 	// Navigate(StartPath);
		// };
	}

	public void Dispose()
	{
		foreach (var webView in _webViews)
		{
			webView.BlazorWebViewInitialized -= OnBlazorWebViewInitialized;
		}
	}

	/// <summary>
	/// Method handling or dispatching messages from WebView.
	/// </summary>
	/// <param name="messageType"></param>
	/// <param name="message"></param>
	/// <returns></returns>
	[JSInvokable]
	public static async Task<object> DispatchMessage(string messageType, JsonDocument message)
	{
		var type = Type.GetType(messageType);

		if (type == null)
		{
			return new
			{
				__DispatchError = $"Type {messageType} not found."
			};
		}

		var test = message.Deserialize(type, s_jsonDeserializeOptions);
		return test;
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

	private async void OnBlazorWebViewInitialized(object? sender, BlazorWebViewInitializedEventArgs e)
	{
		try
		{
// #if WINDOWS
// 		var webView = ((Microsoft.UI.Xaml.Controls.WebView2)WebView.Handler.PlatformView);
// 		webView.CoreWebView2.Settings.IsWebMessageEnabled = true;
// 		webView.WebMessageReceived += (
// 			Microsoft.UI.Xaml.Controls.WebView2 sender,
// 			Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs args
// 		) =>
// 		{
// 			//__bwv:["BeginInvokeDotNet","2","__dispatch","Dispatch",0,"[1,2,3,\"foo\",{\"bar\":\"nice\"}]"]
// 			var str = args.TryGetWebMessageAsString();
// 			if (str.StartsWith("__bwv:[\"BeginInvokeDotNet\""))
// 			{
// 				var asJson = args.WebMessageAsJson;
// 				var rawMessage = JsonSerializer.Deserialize<JsonElement[]>(str.Substring("__bwv:".Length));
// 				var parameters = JsonSerializer.Deserialize<JsonElement[]>(rawMessage[5].GetString());
// 				var y = 1;
// 			}
// 			// WebView.TryDispatchAsync(async services =>
// 			// {
// 			// 	var runtime = services.GetService<IJSRuntime>();
// 			//
// 			// 	if (runtime != null)
// 			// 	{
// 			// 		await runtime.InvokeAsync<bool>("window.alert", "Hello from C#!");
// 			// 	}
// 			// });
// 		};
// #elif MACCATALYST || IOS
// 			((WebKit.WKWebView)Handler.PlatformView).Configuration.UserContentController.AddScriptMessageHandler(new WKHandler(), "__dispatch");
// #elif ANDROID
// #elif TIZEN
// #endif

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
		catch (Exception)
		{

		}
	}
}
