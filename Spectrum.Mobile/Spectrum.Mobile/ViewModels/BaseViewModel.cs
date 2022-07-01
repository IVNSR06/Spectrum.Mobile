using Spectrum.Mobile.Services;

namespace Spectrum.Mobile.ViewModels
{
    public class BaseViewModel
    {
        #region Properties
        public ISpectrumService _spectrumService;
        
        public string Title { get; set; }
        #endregion
        public BaseViewModel(ISpectrumService spectrumService)
        {
            _spectrumService = spectrumService;
        }
    }
}