using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Spectrum.Mobile.Services;
using Xamarin.Forms;

namespace Spectrum.Mobile.ViewModels
{
    public abstract class BaseViewModel : BindableObject
    {
        #region Properties
        public ISpectrumService _spectrumService;
        public INavigationService _navigationService;
        
        public string Title { get; set; }
        #endregion
        public BaseViewModel(ISpectrumService spectrumService, INavigationService navigationService)
        {
            _spectrumService = spectrumService;
            _navigationService = navigationService;
        }
        
        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = GetMemberInfo(property).Name;
            OnPropertyChanged(name);
        }
        
        private MemberInfo GetMemberInfo(Expression expression)
        {
            MemberExpression operand;
            LambdaExpression lambdaExpression = (LambdaExpression)expression;
            if (lambdaExpression.Body as UnaryExpression != null)
            {
                UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
                operand = (MemberExpression)body.Operand;
            }
            else
            {
                operand = (MemberExpression)lambdaExpression.Body;
            }
            return operand.Member;
        }

        public virtual Task InitializeAsync(object parameter)
        {
            return Task.FromResult(false);
        }
    }
}