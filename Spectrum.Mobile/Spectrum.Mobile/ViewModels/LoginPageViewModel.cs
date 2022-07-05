using System;
using System.Windows.Input;
using Spectrum.Mobile.Helper;
using Spectrum.Mobile.Model.Request;
using Spectrum.Mobile.Model.Response;
using Spectrum.Mobile.Services;
using Xamarin.Forms;

namespace Spectrum.Mobile.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Properties

        private LoginRequest _loginRequest;
        public LoginRequest LoginRequest
        {
            get => _loginRequest;
            set
            {
                _loginRequest = value;
                RaisePropertyChanged(() => _loginRequest);
            }
        }

        public ICommand LoginCommand { get; }
        #endregion
        public LoginPageViewModel(ISpectrumService spectrumService, INavigationService navigationService) : base(spectrumService, navigationService)
        {
            LoginCommand = new Command(Login);
            LoginRequest = new LoginRequest();
        }

        private async void Login()
        {
            try
            {
                var result = await _spectrumService.PostAsync<User>(LoginRequest, Constants.Login);

                if (result != null && !string.IsNullOrEmpty(result.Token))
                {
                    await _navigationService.NavigateToAsync<HomePageViewModel>(result);
                }
            }
            catch (Exception e)
            {
                IsErrorLabelVisible = true;
                ErrorMessage = e.Message;
            }
        }
    }
}