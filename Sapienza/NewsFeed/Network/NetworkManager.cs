using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Sapienza.NewsFeed.Model;
using Sapienza.NewsFeed;

namespace Sapienza.NewsFeed.Network
{
	public sealed class NetworkManager
    {
        public static NetworkManager network_manager = new NetworkManager();
        //public static string network_url = "http://feeds.sciencedaily.com/sciencedaily?format=xml";
		public static string network_url = "http://megaflux.macg.co/";

        private NetworkManager()
        {
        }

        public static NetworkManager Instance
        {
            get
            {
                return network_manager;
            }
        }

        public async Task<List<FeedItem>> GetSyncFeedAsync()
        {
            if (this.IsConnected())
            {
                Debug.WriteLine("Starting network load feeds");
                Debug.WriteLine("at : " + new DateTime().ToString());

                Uri uri = new Uri(network_url);
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(uri);
                String response_string = await response.Content.ReadAsStringAsync();

                Debug.WriteLine("Feeds received at : " + new DateTime().ToString());

                Debug.WriteLine("Start to parse");

                FeedItemParser parser = new FeedItemParser();
                List<FeedItem> list = await Task.Run(() => parser.ParseFeed(response_string));
                return list;
            }
            return null;
        }

        public bool IsConnected()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            return false;
        }
    }
}
