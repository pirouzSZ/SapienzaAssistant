using System;
using System.Collections.Generic;
using Sapienza.Bot.ViewModel;
using Xamarin.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sapienza
{
    public partial class BotPage : ContentPage
    {
		private BotMainViewModel _model = new BotMainViewModel();

		public BotPage()
        {
            InitializeComponent();
            this.BindingContext = _model;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _model.StartConversation();
        }

    
    }
}
