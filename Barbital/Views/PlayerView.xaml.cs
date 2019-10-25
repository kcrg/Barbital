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

            //scheduleView.ScrollTo(); = (BindingContext as PlayerViewModel).IsNowPosition;
        }
    }
}