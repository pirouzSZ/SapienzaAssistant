using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Sapienza.NewsFeed.Model;
using Xamarin.Forms;


namespace Sapienza.NewsFeed
{
	public static class Singleton
    {
        //public static List<ImageHTML> Images = new List<ImageHTML>();

        public static List<FeedItem> feeds = new List<FeedItem>();

    }



    public class FeedItemParser
    {

        public FeedItemParser()
        {
        }

        public List<FeedItem> ParseFeed(string response)
        {
            if (response == null)
            {
                return null;
            }

            Debug.WriteLine("RSS Feed received. parsing values");

            // TODO : this could crash, if the response is not complete, or if response is ean error instead of xml, or if response is json ??? (does RSS feed exist in json ???)
            // catch this ? to be confirmed : what is the best way need to be used

            XDocument doc = XDocument.Parse(response);

            foreach (var item in doc.Descendants("item"))
            {
                FeedItem feed = new FeedItem();

                // get some feed values. not really useful in this application

                feed.link = item.Element("link").Value.ToString();
                feed.pubdate = item.Element("pubDate").Value.ToString();
                feed.guid = item.Element("guid").Value.ToString();
                feed.imageURL = "";        // by default, there is no image

                // title is html. in this case, we need to use something like HTML Label
                feed.title = HtmlToPlainText(item.Element("title").Value.ToString()); //.Replace(@"\", string.Empty);    // Regex.Unescape(item.Element("title").Value.ToString());

                // Desvcription is html also
                string str = item.Element("description").Value.ToString();

                // check if description contains an image. if yes, we will display the first one, as thumbnail of the Feed list
                //
                if (str.Contains("<img"))
                {
                    // the description contain at least one image :  we will get the first one as description thumbnail
                    // TODO : the problem here is that the image could be an advertising !. 
                    // what to do to manage it better ???

                    var desc = str;
                    var i = desc.IndexOf("<img src=");
                    if (i != -1)
                    {
                        var index2 = desc.IndexOf(".jpg", i);
                        if (index2 != -1 && index2 > i)
                        {
                            // TODO : this is dangerous, because the length of desc has to be chacked before doing that.
                            // 
                            var img = desc.Substring(i + 10, index2 - i - 6);
                            feed.imageURL = img;
                            //feed.ImageUrl = img;

                        }
                    }
                }

    

                if (str.Contains("Rendre compatible"))
                {

                    Debug.WriteLine("ok");

                    var text0 = HtmlToPlainText(str);
                }


                // convert html to plain text
                var text = HtmlToPlainText(str);
                // keep a short part of the description string
                var max = 200;
                if (text.Length < max)
                {
                    max = text.Length;
                }
                feed.description = text.Substring(0, max) + " ...";


                Singleton.feeds.Add(feed);
            }

            Debug.WriteLine("Feed parsed properly");
            Debug.WriteLine("Nb lines of feeds : " + Singleton.feeds.Count.ToString());

            Debug.WriteLine("Starting to load images in async task at : " + new DateTime().ToString());

            //Task.Run(async () => { await LoadImages(); }); // Singleton.feeds ); });

            Debug.WriteLine("leaving parse Feed method at  : " + new DateTime().ToString());

            return Singleton.feeds;
        }



        // co,nvert html to plain text, removing the tags
        // https://stackoverflow.com/questions/286813/how-do-you-convert-html-to-plain-text
        //
        private static string HtmlToPlainText(string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);

            // olivier added : convert \n<p>... into <p>...
            text = tagWhiteSpaceRegex.Replace(text, "<");


            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }      

    }
}
