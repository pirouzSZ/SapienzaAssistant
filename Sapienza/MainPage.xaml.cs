using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sapienza
{
	public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
			IsPresented = true;
        }
		void Menu1(object sender, EventArgs e)
        {
			Detail = new NavigationPage(new NewsPage());
            IsPresented = false;
        }
        
		void Menu2(object sender, EventArgs e)
        {
			Detail = new NavigationPage(new BotPage2());
			IsPresented = false;
        }
		void Menu3(object sender, EventArgs e)
        {
			Detail = new NavigationPage(new LocationPage());
			IsPresented = false;
        }

		void Menu4(object sender, EventArgs e)
        {
			Detail = new NavigationPage(new AboutPage());
            IsPresented = false;
        }
    }
}
