using System.Linq;
using MapKit;
using Spectrum.Mobile.Controls;
using Spectrum.Mobile.iOS.Renderer;
using Spectrum.Mobile.Model;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace Spectrum.Mobile.iOS.Renderer
{
    public class CustomMapRenderer : MapRenderer
    {
    }
}