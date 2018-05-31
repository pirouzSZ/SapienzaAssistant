using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace Sapienza
{
	public class MainViewModel : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainViewModel()
        {

            PinCollection.Add(new Pin() { Position = MyPosition, Type = PinType.Generic, Label = "Scala C" });

            Task.Run(async () =>
            {
                var position = await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync();
                MyPosition = new Position(position.Latitude, position.Longitude);
            });
        }

        

        private ObservableCollection<Pin> _pinCollection = new ObservableCollection<Pin>();
        public ObservableCollection<Pin> PinCollection { get { return _pinCollection; } set { _pinCollection = value; OnPropertyChanged(); } }

		private Position scalac = new Position(41.903743, 12.517133);
		public Position MyPosition { get { return scalac; } set { scalac = value; OnPropertyChanged(); } }
    }
}
