using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents an icon that uses a vector path as its content.
    /// </summary>
    [TemplatePart(Name = "PART_Path", Type = typeof(Path))]
    public sealed class PathIcon : IconElement
    {
        /// <summary>
        /// Initializes a new instance of the PathIcon class.
        /// </summary>
        public PathIcon() : base()
        {
            this.DefaultStyleKey = typeof(PathIcon);
        }

        #region Properties

        /// <summary>
        /// Gets or sets a Geometry that specifies the shape to be drawn.
        /// <para>In XAML this can also be set using the Path Markup Syntax.</para>
        /// </summary>
        public Geometry Data
        {
            get => (Geometry)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Data dependency property.
        /// </summary>
        public static readonly DependencyProperty DataProperty =
                DependencyProperty.Register(nameof(Data), typeof(Geometry), typeof(PathIcon), new PropertyMetadata(null));

        #endregion
    }
}
