using System;
using System.Diagnostics;
using System.Collections.Generic;
using Sapienza.NewsFeed.Model;
using Xamarin.Forms;

namespace Sapienza.NewsFeed.CellViews
{
	public partial class FeedCell : ViewCell    // FastCell
    {

        public FeedCell()
        {
            InitializeComponent();

            Debug.WriteLine("new cell ");

            //image.Source = null;

            this.Appearing += async (object sender, EventArgs e) => {

                // Called when user scroll the listview, and a cell appear on the screen !

                //await refreshData();
                Debug.WriteLine("re new cell ");

                //image.Source = null;

            };
        }


    }
}
