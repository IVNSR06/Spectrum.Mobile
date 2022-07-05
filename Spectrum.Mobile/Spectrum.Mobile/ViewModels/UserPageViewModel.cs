using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Spectrum.Mobile.Helper;
using Spectrum.Mobile.Model;
using Spectrum.Mobile.Services;
using Xamarin.Forms;

namespace Spectrum.Mobile.ViewModels
{
    public class UserPageViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<User> UserList { get; private set; }

        public ICommand NavgateToDetailProfileCommand { get; }
        #endregion
        
        public UserPageViewModel(ISpectrumService spectrumService, INavigationService navigationService):base(spectrumService, navigationService)
        {
            UserList = new ObservableCollection<User>();
            NavgateToDetailProfileCommand = new Command(NavgateToDetailProfile);
            Task.Run(async () => await GetUserList()).Wait();
        }

        #region Methods

        private async Task GetUserList()
        {
            var result = await _spectrumService.GetAsync<ObservableCollection<User>>(Constants.GetUserEndPoint);
            result[0].Address.Geo = new Geo { Lat = "36.16100823506389", Lng = "-86.77812217160002" };
            result[1].Address.Geo = new Geo { Lat = "36.14118885441203", Lng = "-86.7936325493875" };
            result[2].Address.Geo = new Geo { Lat = "36.210761169259875", Lng = "-86.69259769131985" };
            UserList = result;
        }
        
        private async void NavgateToDetailProfile(object obj)
        {
            var selectionChanged = obj as SelectionChangedEventArgs;
            await _navigationService.NavigateToAsync<PostPageViewModel>(selectionChanged.CurrentSelection);
        }
        #endregion
    }
}