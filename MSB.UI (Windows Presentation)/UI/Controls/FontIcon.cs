using System.Windows.Controls;
using System.Windows;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents an icon that uses a glyph from the specified font.
    /// </summary>
    [TemplatePart(Name = "PART_Glyph", Type = typeof(TextBlock))]
    public sealed class FontIcon : IconElement
    {
        /// <summary>
        /// Initializes a new instance of the FontIcon class.
        /// </summary>
        public FontIcon() : base()
        {
            this.DefaultStyleKey = typeof(FontIcon);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the character code that identifies the icon glyph.
        /// </summary>
        public string Glyph
        {
            get => (string)GetValue(GlyphProperty);
            set => SetValue(GlyphProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Glyph dependency property.
        /// </summary>
        public static readonly DependencyProperty GlyphProperty =
                DependencyProperty.Register(nameof(Glyph), typeof(string), typeof(FontIcon), new PropertyMetadata(""));

        #endregion
    }
}
