using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Spectrum.Mobile.Helper;
using Spectrum.Mobile.Model;
using Spectrum.Mobile.Model.Response;
using Spectrum.Mobile.Services;
using Xamarin.Forms;

namespace Spectrum.Mobile.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private string _welcomeMessage;
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set
            {
                _welcomeMessage = value;
                RaisePropertyChanged(()=> _welcomeMessage);
            }
        }
        
        public ObservableCollection<string> CategoryList { get; set; }
        
        public ObservableCollection<string> BrandList { get; set; }

        public ObservableCollection<Product> ProductList { get; set; }

        private ProductResponse _productResponse;
        public ProductResponse ProductResponse
        {
            get => _productResponse;
            set
            {
                _productResponse = value;
                RaisePropertyChanged(() => _productResponse);
            }
        }
        
        private User _user;
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                RaisePropertyChanged(() => _user);
            }
        }
        
        public ICommand SelectProductCommand { get; }
        
        public HomePageViewModel(ISpectrumService spectrumService, INavigationService navigationService) : base(spectrumService, navigationService)
        {
            User = new User();
            CategoryList = new ObservableCollection<string>();
            BrandList = new ObservableCollection<string>();
            ProductList = new ObservableCollection<Product>();
            SelectProductCommand = new Command(SelectProduct);
        }

        private async void SelectProduct(object obj)
        {
            var selectionChanged = obj as SelectionChangedEventArgs;
            await _navigationService.NavigateToAsync<ProductDetailPageViewModel>(selectionChanged);
        }

        public override async Task InitializeAsync(object parameter)
        {
            User = (User)parameter;
            WelcomeMessage = string.Format(Resources.Resources.WelcomeMessage, User.FirstName);
            var result = await _spectrumService.GetAsync<ProductResponse>(Constants.GetProducts);

            if (result.Products.Any())
            {
                result.Products.ForEach(x => ProductList.Add(x));
            }
        }
    }
}