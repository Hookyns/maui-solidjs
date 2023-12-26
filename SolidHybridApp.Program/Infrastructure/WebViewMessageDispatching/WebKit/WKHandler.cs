namespace SolidHybridApp.Program.Infrastructure.WebViewMessageDispatching.WebKit;

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
