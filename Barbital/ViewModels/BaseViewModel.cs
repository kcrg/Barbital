using Prism.Mvvm;

namespace Barbital.ViewModels
{
    internal class BaseViewModel : BindableBase
    {
        public string PageTitle { get; set; }

        public BaseViewModel()
        {
        }
    }
}