using Xamarin.Forms;

namespace Barbital.Controls
{
    public partial class BaseShellTab : Tab
    {
        public BaseShellTab()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty GlyphProperty = BindableProperty.Create(nameof(Glyph), typeof(string), typeof(BaseShellTab), default(string), BindingMode.OneWay);
        public string Glyph
        {
            get => (string)GetValue(GlyphProperty);
            set => SetValue(GlyphProperty, value);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == GlyphProperty.PropertyName)
            {
                fontImageSource.Glyph = Glyph;
            }
        }
    }
}