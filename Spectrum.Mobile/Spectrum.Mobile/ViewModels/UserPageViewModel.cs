using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Spectrum.Mobile.Helper;
using Spectrum.Mobile.Model;
using Spectrum.Mobile.Services;
using Spectrum.Mobile.Views;
using Xamarin.Forms;

namespace Spectrum.Mobile.ViewModels
{
    public class UserPageViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<User> UserList { get; private set; }

        public ICommand NavgateToDetailProfileCommand { get; private set; }
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