using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Spectrum.Mobile.Helper;
using Spectrum.Mobile.Model;
using Spectrum.Mobile.Services;

namespace Spectrum.Mobile.ViewModels
{
    public class UserPageViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<User> UserList { get; private set; }

        #endregion
        
        public UserPageViewModel(ISpectrumService spectrumService):base(spectrumService)
        {
            Task.Run(async () => await GetUserList());
        }

        #region Methods

        private async Task GetUserList()
        {
            var result = await _spectrumService.GetAsync<IList<User>>(Constants.GetUserEndPoint);
        }
        #endregion
    }
}