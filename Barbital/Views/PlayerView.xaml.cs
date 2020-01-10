using Barbital.Models;
using Barbital.ViewModels;
using System.Linq;
using Xamarin.Forms;

namespace Barbital.Views
{
    public partial class PlayerView : ContentPage
    {
        public PlayerView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            PlayerViewModel viewModel = BindingContext as PlayerViewModel;
            ScheduleModel isNow = viewModel.Schedule.FirstOrDefault(m => m.IsNow);
            ScheduleView.ScrollTo(isNow);
        }
    }
}