using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Sapienza.NewsFeed.Model;
using Sapienza.NewsFeed.ViewModel;
using Xamarin.Forms;

namespace Sapienza
{
	public partial class NewsPage : ContentPage
    {


        RSSFeedViewModel RSSFeedViewModelObject;

		public NewsPage()
        {
            InitializeComponent();

            Debug.WriteLine("Starting viewModel");
            RSSFeedViewModelObject = new RSSFeedViewModel(Navigation);
            BindingContext = RSSFeedViewModelObject;

      

            // start the first refresh of the listview
            FeedListView.IsRefreshing = true;
            FeedListView.BeginRefresh();

            // add select item event
            FeedListView.ItemSelected += (sender, e) => {
           

                var item = ((ListView)sender).SelectedItem;
                var feed = (FeedItem)item;

               
                webview.Source = feed.guid;
                

                web.IsVisible = true;

            };
        }

        // close the web view button click
        void Handle_Clicked(object sender, System.EventArgs e)
        {
           
            web.IsVisible = false;
            webview.Source = "";
        }



    }
}
