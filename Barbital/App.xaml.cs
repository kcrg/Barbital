using Barbital.Services;
using Barbital.Services.Implementation;
using Barbital.ViewModels;
using Barbital.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Barbital
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            MainPage = new AppShellView();

            Routing.RegisterRoute("appshellview", typeof(AppShellView));
            Routing.RegisterRoute("playerview", typeof(PlayerView));
            Routing.RegisterRoute("newslist", typeof(NewsListView));
            Routing.RegisterRoute("appshellview/newslistview/newsitemview", typeof(NewsItemView));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register(typeof(ISettingsService), typeof(SettingsService));
            containerRegistry.Register(typeof(INewsfeedService), typeof(NewsfeedService));

            containerRegistry.RegisterForNavigation<AppShellView, AppShellViewModel>();
            containerRegistry.RegisterForNavigation<PlayerView, PlayerViewModel>();
            containerRegistry.RegisterForNavigation<NewsListView, NewsListViewModel>();
            containerRegistry.RegisterForNavigation<NewsItemView, NewsItemViewModel>();
        }
    }
}