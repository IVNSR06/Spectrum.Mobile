using System.Threading.Tasks;

namespace Spectrum.Mobile.Services
{
    public interface ISpectrumService
    {
        Task<T> GetAsync<T>(string method);
    }
}