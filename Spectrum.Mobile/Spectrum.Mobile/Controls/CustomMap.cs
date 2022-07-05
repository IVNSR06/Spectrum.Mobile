using System;
using Spectrum.Mobile.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Spectrum.Mobile.Controls
{
    public class CustomMap : Map
    {
        public CustomMap()
        {
        }

        public static readonly BindableProperty CoordinatesProperty = BindableProperty.Create(nameof(Coordinates),
            typeof(Geo),
            typeof(CustomMap),
            propertyChanged: OnCoordinatesPropertyChanged);

        private static void OnCoordinatesPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (CustomMap)bindable;
            var location = (Geo)newvalue;
            var position = new Position(Convert.ToDouble(location.Lat), Convert.ToDouble(location.Lng));
            var distance = new Distance(150);
            control.MoveToRegion(MapSpan.FromCenterAndRadius(position, distance));
            var pin = new Pin
            {
                Position = new Position(position.Latitude, position.Longitude),
                Label = string.Empty
            };
            control.Pins.Add(pin);
        }

        public Model.Geo Coordinates    
        {
            get => (Geo)GetValue(CoordinatesProperty);
            set => SetValue(CoordinatesProperty, value);
        }

        private Position _positionToMove;
        public Position PositionToMove
        {
            get => _positionToMove;
            set
            {
                if (_positionToMove == value)
                    return;
                _positionToMove = value;
                OnPropertyChanged();
                MoveToRegion(MapSpan.FromCenterAndRadius(new Position(PositionToMove.Latitude, PositionToMove.Longitude), Distance.FromKilometers(8.0)));
            }
        }
    }
}