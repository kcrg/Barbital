using Prism.Mvvm;

namespace Barbital.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        public string PageTitle { get; set; }

        public BaseViewModel()
        {
        }
    }
}