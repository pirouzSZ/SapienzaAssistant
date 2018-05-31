using Xamarin.Forms;

namespace Sapienza
{
	public class BotPage2 : ContentPage
	{
		public BotPage2()
		{
			var browser = new WebView();
			Title = "Assistant";
			//browser.Source = "https://webchat.botframework.com/embed/mysapienzabot?s=rX8IqFnv8oA.cwA.PRc.V47d_Nrz0fMyNNJCOz-jUx4CPCJx7SYXLUSs5l_8H-A";
			browser.Source = "https://console.dialogflow.com/api-client/demo/embedded/9a940d3a-fb1d-4a98-9c9e-ddd9a4b3e994";
			this.Content = browser;
		}
	}
}

