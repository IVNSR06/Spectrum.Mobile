using Spectrum.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spectrum.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostPage : ContentPage
    {
        public PostPage()
        {
            InitializeComponent();
            BindingContext = App.ServiceProvider.GetService(typeof(PostPageViewModel));
        }
    }
}