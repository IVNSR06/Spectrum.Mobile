using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Spectrum.Mobile.Helper;

namespace Spectrum.Mobile.Services
{
    public class SpectrumService : ISpectrumService
    {
        public async Task<T> GetAsync<T>(string method)
        {
            return await Constants.BaseURL.AppendPathSegment(method).GetJsonAsync<T>();
        }
    }
}