using Prism.Mvvm;

namespace Barbital.ViewModels
{
    internal class AppShellViewModel : BindableBase
    {
        public string PlayerTabTitle { get; set; }
        public string NewsTabTitle { get; set; }

        public AppShellViewModel()
        {
            PlayerTabTitle = "Player";
            NewsTabTitle = "News";
        }
    }
}