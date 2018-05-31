using System;
using System.Collections.Generic;
using Sapienza.NewsFeed;
using Xamarin.Forms;


namespace Sapienza.NewsFeed
{
	public partial class WebPage : ContentPage
    {
        public string WebviewSource { get; set; }
        public WebPage()
        {
            InitializeComponent();

        }
        public WebPage(string s)
        {
            InitializeComponent();
            WebviewSource = s;
            Title = "Web";
            BindingContext = this;
        }
    }
}
