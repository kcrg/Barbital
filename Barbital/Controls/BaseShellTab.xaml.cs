using Xamarin.Forms;

namespace Barbital.Controls
{
    public partial class BaseShellTab : Tab
    {
        public BaseShellTab()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty FontIconProperty = BindableProperty.Create(nameof(FontIcon), typeof(string), typeof(BaseShellTab), default(string), BindingMode.OneWay);
        public string FontIcon
        {
            get => (string)GetValue(FontIconProperty);
            set => SetValue(FontIconProperty, value);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == FontIconProperty.PropertyName)
            {
                fontImageSource.Glyph = FontIcon;
            }
        }
    }
}