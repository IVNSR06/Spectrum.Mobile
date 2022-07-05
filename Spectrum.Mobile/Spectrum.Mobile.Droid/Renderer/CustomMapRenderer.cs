using Android.Gms.Maps.Model;
using Spectrum.Mobile.Controls;
using Spectrum.Mobile.Droid.Renderer;
using Spectrum.Mobile.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;

[assembly:ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace Spectrum.Mobile.Droid.Renderer
{
    public class CustomMapRenderer : MapRenderer
    {
    }
}