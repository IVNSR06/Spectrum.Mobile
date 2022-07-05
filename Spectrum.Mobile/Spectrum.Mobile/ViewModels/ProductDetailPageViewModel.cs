using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectrum.Mobile.Model;
using Spectrum.Mobile.Services;
using Xamarin.Forms;

namespace Spectrum.Mobile.ViewModels
{
    public class ProductDetailPageViewModel : BaseViewModel
    {
        private Product _product;

        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                RaisePropertyChanged(() => _product);
            }
        }
        
        public ProductDetailPageViewModel(ISpectrumService spectrumService, INavigationService navigationService) : base(spectrumService, navigationService)
        {
            Product = new Product();
        }

        public override Task InitializeAsync(object parameter)
        {
            var demo = (SelectionChangedEventArgs)parameter;
            Product = (Product)demo.CurrentSelection.FirstOrDefault();
            return base.InitializeAsync(parameter);
        }
    }
}