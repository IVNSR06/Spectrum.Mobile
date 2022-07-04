using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectrum.Mobile.Model;
using Spectrum.Mobile.Services;

namespace Spectrum.Mobile.ViewModels
{
    public class PostPageViewModel : BaseViewModel
    {
        #region Properties

        private User _selectedUser;

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                RaisePropertyChanged(() => SelectedUser);
            }
        }
        #endregion
        public PostPageViewModel(ISpectrumService spectrumService, INavigationService navigationService) : base(spectrumService, navigationService)
        {
            
        }

        public override Task InitializeAsync(object parameter)
        {
            SelectedUser = (User)((List<object>)parameter).FirstOrDefault();
            return base.InitializeAsync(parameter);
        }
    }
}