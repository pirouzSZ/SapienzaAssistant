using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sapienza.NewsFeed.Model
{
	public class FeedItem : Image
    {

        public FeedItem()
        {
			
        }


        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string pubdate { get; set; }
        public string guid { get; set; }
        public string imageURL { get; set; }
             


    }
}
