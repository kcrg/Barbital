using Xamarin.Forms;

namespace Barbital.Controls
{
    public partial class BaseToolbarItem : ToolbarItem
    {
        public BaseToolbarItem()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty GlyphProperty = BindableProperty.Create(nameof(Glyph), typeof(string), typeof(BaseToolbarItem), default(string), BindingMode.OneWay);
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